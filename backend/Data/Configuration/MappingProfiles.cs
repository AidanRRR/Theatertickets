using AutoMapper;
using backend.Domain;
using backend.Domain.Features.Voorstelling;

namespace backend.Data.Configuration
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AddVoorstelling.Request, VoorstellingEntity>();
            CreateMap<VoorstellingEntity, AddVoorstelling.Request>();
        }
    }
}