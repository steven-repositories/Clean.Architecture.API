using Microsoft.AspNetCore.Mvc;

namespace TAN_10042024.Framework.Controllers {
    [Route("api/file")]
    [ApiController, Produces("application/json")]
    public class FileUploadController : ControllerBase {
        public FileUploadController() {

        }

        [HttpPost, Route("upload/persons")]
        public IActionResult UploadPersons([FromForm] IFormFile file) {

            return Ok(new {

            });
        }
    }
}
