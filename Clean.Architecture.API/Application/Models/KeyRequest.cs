namespace Clean.Architecture.API.Application.Models {
    public class KeyRequest {
        public required string ClientName { get; set; }
        public required string GrantType { get; set; }
    }
}
