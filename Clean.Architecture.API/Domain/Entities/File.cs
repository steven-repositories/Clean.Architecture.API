using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class File : Entity {
        public required string Name { get; set; }
        public required string Content { get; set; }
    }
}
