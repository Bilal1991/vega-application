import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Makes } from '../models/makes';
import { Feature } from '../models/feature';
import { Vehicle } from '../models/vehicle';
import { SaveVehicle } from '../models/saveVehicle';
@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) { }
  getMakes()
  {
    return this.http.get<Makes[]>('/api/Makes');
  }
  getFeatures() {
    return this.http.get<Feature[]>('/api/Features');
  }
  Create(vehicle) {
    return this.http.post('/api/Vehicles', vehicle);
  }
  Update(vehicle: SaveVehicle) {
    return this.http.put('/api/Vehicles/' + vehicle.id, vehicle);
  }
  GetVehicleById(id) {
    
    return this.http.get<Vehicle>('/api/Vehicles/' + id);
  }
  GetVehicles() {

    return this.http.get<Vehicle[]>('/api/Vehicles');
  }
  DeleteVehicle(id) {

    return this.http.delete('/api/Vehicles/' + id);
  }
}
