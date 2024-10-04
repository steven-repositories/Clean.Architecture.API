using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TAN_10042024.Application.Abstractions;

namespace TAN_10042024.Framework.Controllers {
    [Route("api/report")]
    [ApiController, Produces("application/json")]
    public class ReportController : ControllerBase {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService) {
            _reportService = reportService;
        }

        [HttpGet, Route("files")]
        public IActionResult ReportFiles() {
            var files = _reportService.ReportFiles();
            
            return Ok(JsonConvert.SerializeObject(files));
        }
    }
}
