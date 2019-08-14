using AutoMapper;
using System.Linq;
using vega_application.Domain.Models;
using vega_application.Resources;

namespace vega_application.Mapping
{
    public class RessourceToModelMappingProfile : Profile
    {
        public RessourceToModelMappingProfile()
        {
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v=>v.Id, opt=>opt.Ignore())
                .ForMember(v=>v.ContactName,opt=>opt.MapFrom(vr=>vr.contact.name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.contact.email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.contact.phone))
                .ForMember(v => v.VehicleFeature, opt => opt.Ignore())
                .AfterMap((vr,v)=> {
                 var RemovedFeatures = v.VehicleFeature.Where(f => !vr.feature.Contains(f.FeatureId)).ToList();
                    foreach (var f in RemovedFeatures)
                    {
                        v.VehicleFeature.Remove(f);
                    }
                 var AddNewFeature = vr.feature.Where(id => !v.VehicleFeature.Any(vf => vf.FeatureId == id))
                    .Select(id => new VehicleFeature { FeatureId = id }).ToList();
                foreach (var f in AddNewFeature)
                {
                    v.VehicleFeature.Add(f);
                }
                });
        }
    }
}
