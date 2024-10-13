using AutoMapper;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Profiles {
    public class ApiSessionsProfile : Profile {
        public ApiSessionsProfile() {
            CreateMap<ApiSessionSchema, ApiSession>();
            CreateMap<ApiSession, ApiSessionSchema>();
        }
    }
}
