namespace Clean.Architecture.API.Application.Models {
    public class FileReportResponse {
        public required int Count { get; set; }
        public required List<FileReport> Files { get; set; }
    }

    public class FileReport {
        public required string FileName { get; set; }
        public required string ProcessedOn { get; set; }
    }
}
