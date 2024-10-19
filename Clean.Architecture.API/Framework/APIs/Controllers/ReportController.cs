using Microsoft.AspNetCore.Mvc;
using TAN_10042024.Application.Abstractions;

namespace TAN_10042024.Framework.APIs.Controllers {
    [Route("api/report")]
    [ApiController, Produces("application/json")]
    public class ReportController : ControllerBase {
        private readonly IReport _reportService;

        public ReportController(IReport reportService) {
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
