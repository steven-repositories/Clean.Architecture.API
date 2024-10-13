using AutoMapper;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Profiles {
    public class ClientProfile : Profile {
        public ClientProfile() {
            CreateMap<ClientSchema, Client>();
            CreateMap<Client, ClientSchema>();
        }
    }
}
