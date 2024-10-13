using AutoMapper;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Profiles {
    public class ApiSessionProfile : Profile {
        public ApiSessionProfile() {
            CreateMap<ApiSessionSchema, ApiSession>()
                .ForMember(member => member.Id, option => option.Ignore())
                .ForMember(member => member.CreatedDateTime, option => option.MapFrom(authSession => DateTime.Now));

            CreateMap<ApiSession, ApiSessionSchema>();
        }
    }
}
