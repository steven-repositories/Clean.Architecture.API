using Microsoft.AspNetCore.Mvc;
using Clean.Architecture.API.Application.Abstractions;
using Clean.Architecture.API.Application.Utilities;
using static Clean.Architecture.API.Application.Utilities.Exceptions;

namespace Clean.Architecture.API.Framework.APIs.Controllers {
    [Route("api/file")]
    [ApiController, Produces("application/json")]
    public class FileUploadController : ControllerBase {
        private readonly IFileUpload _fileUploadService;

        public FileUploadController(IFileUpload fileUploadService) {
            _fileUploadService = fileUploadService;
        }

        [HttpPost, Route("upload/persons")]
        public async Task<IActionResult> UploadPersons([FromForm] IFormFile file) {
            if (!HttpContext.Items.TryGetValue("FileContent", out var fileContent)) {
                throw new ApiException("The content of the file cannot be found.");
            }

            if (fileContent!.IsNullOrEmpty()) {
                throw new ApiException("The file does not have a content.");
            }

            await _fileUploadService.Upload(file.FileName, (string)fileContent!);

            return Ok(new {
                success = true,
                data = new {
                    message = "Successfully uploaded the JSON file!"
                }
            });
        }
    }
}
