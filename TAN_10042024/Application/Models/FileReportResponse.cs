namespace TAN_10042024.Application.Models {
    public class FileReportResponse {
        public int Count { get; set; }
        public List<FileReport> Files { get; set; }
    }

    public class FileReport {
        public string FileName { get; set; }
        public string ProcessedOn { get; set; }
    }
}
