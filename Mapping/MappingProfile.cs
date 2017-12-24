using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Vig.Controllers.Resources;
using Vig.Models;

namespace Vig.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
             CreateMap<Vehicle, VehicleResource>()
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone } ))
              .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));

            //API Resource to Domain
            CreateMap<VehicleResource, Vehicle>()
            .ForMember(v => v.Id, opt => opt.Ignore())
            .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
            .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
            .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
            // .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id = new VehicleFeature{FeatureId = id})));
            // .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature { FeatureId = id })))

            .ForMember(v => v.Features, op => op.Ignore())
            .AfterMap((vr, v) =>
            {

                //Remove unselected item
                var removeFeatures = new List<VehicleFeature>();
                foreach(var f in v.Features)
                    if(vr.Features.Contains(f.FeatureId))
                   removeFeatures.Add(f);

                //Add newfeatures
                foreach(var id in vr.Features)
                {
                     if(v.Features.Any(f => f.FeatureId == id))
                    v.Features.Add(new VehicleFeature{ FeatureId == id});
                }
            });
        }
    }
}