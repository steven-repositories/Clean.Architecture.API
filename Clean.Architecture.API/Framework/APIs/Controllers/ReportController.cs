using Microsoft.AspNetCore.Mvc;
using Clean.Architecture.API.Application.Abstractions;

namespace Clean.Architecture.API.Framework.APIs.Controllers {
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
