using AutoMapper;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Profiles {
    public class ApiSessionProfile : Profile {
        public ApiSessionProfile() {
            CreateMap<ApiSessionSchema, ApiSession>();
            CreateMap<ApiSession, ApiSessionSchema>();
        }
    }
}
