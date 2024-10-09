using Microsoft.AspNetCore.Mvc;
using TAN_10042024.Application.Abstractions.Controllers;

namespace TAN_10042024.Framework.Controllers
{
    [Route("api/report")]
    [ApiController, Produces("application/json")]
    public class ReportController : ControllerBase {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService) {
            _reportService = reportService;
        }

        [HttpGet, Route("files")]
        public async Task<IActionResult> ReportFiles() {
            var files = await _reportService.ReportFiles();

            return Ok(new {
                success = true,
                data = files
            });
        }
    }
}
