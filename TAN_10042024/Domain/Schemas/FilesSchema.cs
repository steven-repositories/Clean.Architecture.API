namespace TAN_10042024.Domain.Entities {
    public class FilesSchema : Schema {
        public required string FileName { get; set; }
        public required string FileContent { get; set; }
    }
}
