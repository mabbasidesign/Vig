using AutoMapper;
using Vig.Controllers.Resources;
using Vig.Models;

namespace Vig.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
        }
    }
}