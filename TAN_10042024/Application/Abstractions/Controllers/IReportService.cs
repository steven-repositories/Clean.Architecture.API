using TAN_10042024.Application.Models;

namespace TAN_10042024.Application.Abstractions.Controllers {
    public interface IReportService {
        Task<FileReportResponse> ReportFiles();
    }
}
