namespace TAN_10042024.Domain.Entities {
    public class Files : Entity {
        public required string FileName { get; set; }
        public required string FileContent { get; set; }
    }
}
