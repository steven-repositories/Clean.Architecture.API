using Clean.Architecture.API.Domain.Entities;

namespace Clean.Architecture.API.Application.Models {
    public class PersonList {
        public required List<Person> Persons { get; set; }
    }
}
