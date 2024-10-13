using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class File : IEntity {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Content { get; private set; }
        public DateTime CreatedDateTime { get; private set; }

        public File WithName(string name) {
            Name = name;
            return this;
        }

        public File WithContent(string content) {
            Content = content;
            return this;
        }
    }
}
