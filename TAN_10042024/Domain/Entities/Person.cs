using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class Person : ISchema {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Team { get; set; }
        public int? Score { get; set; }
        public DateTime CreatedDateTime { get; private set; }

        public Person() {
            CreatedDateTime = DateTime.Now;
        }
    }
}
