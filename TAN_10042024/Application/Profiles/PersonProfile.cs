using AutoMapper;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Mappers {
    public class PersonProfile : Profile {
        public PersonProfile() {
            CreateMap<PersonSchema, Person>()
                .ForMember(member => member.Id, option => option.Ignore())
                .ForMember(member => member.CreatedDateTime, option => option.MapFrom(authSession => DateTime.Now));

            CreateMap<Person, PersonSchema>();
        }
    }
}
