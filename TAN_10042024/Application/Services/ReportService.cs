using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Application.Abstractions.Repositories;
using TAN_10042024.Application.Models;

namespace TAN_10042024.Application.Services
{
    public class ReportService : IReportService {
        private readonly ILogger<ReportService> _logger;
        private readonly IFilesRepository _filesRepo;
        private readonly IFilesQueryService _filesQueryService;

        public ReportService(ILogger<ReportService> logger, IFilesRepository filesRepo, IFilesQueryService filesQueryService) {
            _logger = logger;
            _filesRepo = filesRepo;
            _filesQueryService = filesQueryService;
        }

        public async Task<FileReportResponse> ReportFiles() {
            var filesProcessed = await _filesQueryService.GetAll();
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
