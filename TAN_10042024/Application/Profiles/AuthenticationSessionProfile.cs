using AutoMapper;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Profiles {
    public class AuthenticationSessionProfile : Profile {
        public AuthenticationSessionProfile() {
            CreateMap<AuthenticationSessionSchema, AuthenticationSession>()
                .ForMember(member => member.Id, option => option.Ignore())
                .ForMember(member => member.CreatedDateTime, option => option.MapFrom(authSession => DateTime.Now));

            CreateMap<AuthenticationSession, AuthenticationSessionSchema>();
        }
    }
}
