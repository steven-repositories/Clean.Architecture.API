using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Application.Abstractions.Repositories;
using TAN_10042024.Application.Models;

namespace TAN_10042024.Application.Services
{
    public class ReportService : IReport {
        private readonly ILogger<ReportService> _logger;
        private readonly IFileRepository _fileRepo;
        private readonly IFileQueryService _fileQueryService;

        public ReportService(ILogger<ReportService> logger, IFileRepository fileRepo, IFileQueryService fileQueryService) {
            _logger = logger;
            _fileRepo = fileRepo;
            _fileQueryService = fileQueryService;
        }

        public async Task<FileReportResponse> ReportFiles() {
            var filesProcessed = await _fileQueryService.GetAll();
            var fileReportList = new List<FileReport>();

            foreach (var file in filesProcessed) {
                var fileReport = new FileReport() {
                    FileName = file.Name,
                    ProcessedOn = file.CreatedDateTime.ToString("g")
                };

                fileReportList.Add(fileReport);
            }

            var fileReportResponse = new FileReportResponse() {
                Count = filesProcessed.Count,
                Files = fileReportList
            };

            return fileReportResponse;
        }
    }
}
