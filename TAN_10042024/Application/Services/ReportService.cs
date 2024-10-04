using Microsoft.IdentityModel.Tokens;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Models;
using TAN_10042024.Framework.Repositories;

namespace TAN_10042024.Application.Services {
    public class ReportService : IReportService {
        private readonly ILogger<ReportService> _logger;
        private readonly FilesRepository _filesRepo;

        public ReportService(ILogger<ReportService> logger, FilesRepository filesRepo) {
            _logger = logger;
            _filesRepo = filesRepo;
        }

        public async Task<FileReportResponse> ReportFiles() {
            var filesProcessed = await _filesRepo.GetAll();
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
