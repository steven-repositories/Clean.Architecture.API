using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class File : ISchema {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
