import * as _ from 'underscore';
import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';
import { Makes, Model } from '../models/makes';
import { Feature } from '../models/feature';
import { Console } from '@angular/core/src/console';
import { log } from 'util';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, forkJoin } from 'rxjs';
import { SaveVehicle } from '../models/saveVehicle';
import { Vehicle } from '../models/vehicle';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: Makes[];
  SelectedMake: Makes
  mode: string
  vehicle: SaveVehicle =
    {
      id: 0,
      isRegisterd: false,
      contact: { Name: "", Email: "", Phone: "" },
      makeId: 0,
      modelId: 0,
      feature: []
    };
  models: Model[];
  VehicleFeatures: Feature[];
  constructor(private vehiclService: VehicleService, private route: ActivatedRoute, private router: Router) {
    route.params.subscribe(p => {
      this.vehicle.id = +p['id'];
      if (this.vehicle.id)
        this.mode = "Edit Vehicle";
      else this.mode = "New Vehicle";
      
    });
  }

  ngOnInit() {
    let sources = [];
    let res = this.vehiclService.getMakes();
    sources.push(res);
    let res1 = this.vehiclService.getFeatures()
    sources.push(res1);
    if (this.vehicle.id) {
      let res3 = this.vehiclService.GetVehicleById(this.vehicle.id);
      sources.push(res3);
    }
  
    forkJoin(sources).subscribe(result => {
      this.makes = result[0];
      this.VehicleFeatures = result[1];

      if (this.vehicle.id) {
        this.setSaveVehicle(result[2]);
        this.PopuplateModel();
      }
    }
    );
  }
  OnMakeChange() {
    this.PopuplateModel();
    delete this.vehicle.modelId;
  }
  private setSaveVehicle(v: Vehicle) {
    this.vehicle.id = v.id;
    this.vehicle.isRegisterd = v.isRegistered;
    this.vehicle.contact = v.contact;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.feature = _.pluck(v.feature, 'id');

  }
  OnFeatureToggle(featureId, $event) {
    if ($event.target.checked)
      this.vehicle.feature.push(featureId);
    else {
      var index = this.vehicle.feature.indexOf(featureId);
      window.console.log("index", index);
      this.vehicle.feature.splice(index, 1);
    }
  }
  private PopuplateModel() {
    this.SelectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = this.SelectedMake ? this.SelectedMake.models : [];
  }
  submit() {

    if (this.vehicle.id)
      this.vehiclService.Update(this.vehicle).subscribe(x => window.console.log("Updated:",x));
    else
      this.vehiclService.Create(this.vehicle).subscribe(x => window.console.log("Added:",x));
  }
  Delete() {

    if (this.vehicle.id && confirm("Are You sure you want to delete this?"))
      this.vehiclService.DeleteVehicle(this.vehicle.id).subscribe(x => this.router.navigate(['']));
    
  }

}
