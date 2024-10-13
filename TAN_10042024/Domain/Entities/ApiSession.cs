using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class ApiSession : ISchema {
        public int Id { get; set; }
        public string? Method { get; set; }
        public string? URL { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
