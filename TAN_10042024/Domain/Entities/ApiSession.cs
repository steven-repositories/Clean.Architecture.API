using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class ApiSession : ISchema {
        public int Id { get; private set; }
        public string? Method { get; private set; }
        public string? URL { get; private set; }
        public DateTime CreatedDateTime { get; private set; }

        public ApiSession WithMethod(string method) {
            Method = method;
            return this;
        }

        public ApiSession WithURL(string url) {
            URL = url;
            return this;
        }
    }
}
