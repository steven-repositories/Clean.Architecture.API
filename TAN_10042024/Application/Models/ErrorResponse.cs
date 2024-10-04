using Newtonsoft.Json;

namespace TAN_10042024.Application.Models {
    public class ErrorResponse {
        [JsonProperty("status")]
        public required string Status { get; set; }
        [JsonProperty("message")]
        public required string Message { get; set; }
    }
}
