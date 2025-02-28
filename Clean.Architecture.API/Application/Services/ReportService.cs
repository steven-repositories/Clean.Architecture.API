using Clean.Architecture.API.Application.Abstractions;
using Clean.Architecture.API.Application.Abstractions.Queries;
using Clean.Architecture.API.Application.Abstractions.Repositories;
using Clean.Architecture.API.Application.Models;

namespace Clean.Architecture.API.Application.Services
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
