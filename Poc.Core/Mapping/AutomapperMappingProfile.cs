using AutoMapper;
using Poc.Core.Models;
using Poc.Infrastructure.Models;

namespace Poc.Core.Mapping
{
    public class AutomapperMappingProfile : Profile
    {
        public AutomapperMappingProfile()
        {
            CreateMap<UserDetailEntity, User>().ReverseMap();
        }
    }
}