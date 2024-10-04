using Microsoft.IdentityModel.Tokens;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Models;
using TAN_10042024.Framework.Repositories;

namespace TAN_10042024.Application.Services {
    public class ReportService : IReportService {
        private readonly ILogger<ReportService> _logger;
        private readonly ApiSessionsRepository _apiSessionsRepo;

        public ReportService(ILogger<ReportService> logger, ApiSessionsRepository apiSessionsRepo) {
            _logger = logger;
            _apiSessionsRepo = apiSessionsRepo;
        }

        public FileReportResponse ReportFiles() {
            var apiSessions = _apiSessionsRepo.GetAll();

            var filesProcessed = apiSessions
                .Where(w => !w.FileContent.IsNullOrEmpty())
                .ToList();

            var fileReportList = new List<FileReport>();

            filesProcessed.ForEach((file) => {
                var fileReport = new FileReport() {
                    FileName = file.FileName,
                    ProcessedOn = file.CreatedDateTime.ToString("g")
                };

                fileReportList.Add(fileReport);
            });

            var fileReportResponse = new FileReportResponse() {
                Count = filesProcessed.Count,
                Files = fileReportList
            };

            return fileReportResponse;
        }
    }
}
