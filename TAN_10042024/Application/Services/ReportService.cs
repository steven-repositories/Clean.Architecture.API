using TAN_10042024.Application.Abstractions.Controllers;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Application.Models;
using TAN_10042024.Infrastructure.Data.Repositories;

namespace TAN_10042024.Application.Services {
    public class ReportService : IReportService {
        private readonly ILogger<ReportService> _logger;
        private readonly FilesRepository _filesRepo;
        private readonly IFilesQueryService _filesQueryService;

        public ReportService(ILogger<ReportService> logger, FilesRepository filesRepo, IFilesQueryService filesQueryService) {
            _logger = logger;
            _filesRepo = filesRepo;
            _filesQueryService = filesQueryService;
        }

        public async Task<FileReportResponse> ReportFiles() {
            var filesProcessed = await _filesQueryService.GetAll();
            var fileReportList = new List<FileReport>();

            foreach (var file in filesProcessed) {
                var fileReport = new FileReport() {
                    FileName = file.FileName,
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
