using Clean.Architecture.API.Application.Models;

namespace Clean.Architecture.API.Application.Abstractions {
    public interface IReport {
        Task<FileReportResponse> ReportFiles();
    }
}
