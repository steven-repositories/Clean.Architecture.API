using AutoMapper;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Mappers {
    public class PersonProfile : Profile {
        public PersonProfile() {
            CreateMap<PersonSchema, Person>();
            CreateMap<Person, PersonSchema>();
        }
    }
}
