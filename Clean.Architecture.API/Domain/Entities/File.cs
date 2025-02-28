using Clean.Architecture.API.Domain.Abstractions;

namespace Clean.Architecture.API.Domain.Entities {
    public class File : Entity {
        public required string Name { get; set; }
        public required string Content { get; set; }
    }
}
