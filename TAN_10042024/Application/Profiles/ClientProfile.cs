using AutoMapper;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Profiles {
    public class ClientProfile : Profile {
        public ClientProfile() {
            CreateMap<ClientSchema, Client>()
                .ForMember(member => member.Id, option => option.Ignore())
                .ForMember(member => member.CreatedDateTime, option => option.MapFrom(authSession => DateTime.Now));

            CreateMap<Client, ClientSchema>();
        }
    }
}
