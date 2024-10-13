using AutoMapper;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Profiles {
    public class AuthenticationSessionProfile : Profile {
        public AuthenticationSessionProfile() {
            CreateMap<AuthenticationSessionSchema, AuthenticationSession>();
            CreateMap<AuthenticationSession, AuthenticationSessionSchema>();
        }
    }
}
