using TAN_10042024.Application.Models;

namespace TAN_10042024.Application.Abstractions {
    public interface IReport {
        Task<FileReportResponse> ReportFiles();
    }
}
