using Microsoft.AspNetCore.Mvc;

namespace TAN_10042024.Framework.Controllers {
    [Route("api/file")]
    [ApiController, Produces("application/json")]
    public class FileUploadController : ControllerBase {
        public FileUploadController() {

        }

        [HttpPost, Route("upload")]
        public IActionResult Upload([FromForm] IFormFile file) {
            var stream = file.OpenReadStream();
            stream.Seek(0, SeekOrigin.Begin);

            return Ok(new {

            });
        }
    }
}
