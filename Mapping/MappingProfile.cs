using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;
using vega_application.Resources;

namespace vega_application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakesResource>();
            CreateMap<Make, KeyValueResource>();
            CreateMap<Model, KeyValueResource>();
            CreateMap<Feature, KeyValueResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForMember(vr => vr.contact, opt => opt.MapFrom(v => new ContactResource
                {
                    name = v.ContactName,
                    phone = v.ContactPhone,
                    email = v.ContactEmail
                }))
                .ForMember(vr => vr.feature, opt => opt.MapFrom(v => v.VehicleFeature.Select(vf => vf.FeatureId)));
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.contact, opt => opt.MapFrom(v => new ContactResource
                {
                    name = v.ContactName,
                    phone = v.ContactPhone,
                    email = v.ContactEmail
                }))
                 .ForMember(vr => vr.feature, opt => opt.MapFrom(v => v.VehicleFeature.
                 Select(vf => new KeyValueResource { id = vf.FeatureId, name = vf.Feature.Name })))
                 .ForMember(vr=>vr.make,opt=>opt.MapFrom(v=>v.Model.Make));


        }
    }
}
