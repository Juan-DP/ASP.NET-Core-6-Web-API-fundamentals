using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _contentType;

        [HttpGet("{fileId}")]
        public ActionResult Get(int fileId) {
            var path = "test.pdf";

            if (!System.IO.File.Exists(path))
            {
                return NoContent();
            }

            if (!_contentType.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octec-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, contentType, Path.GetFileName(path));
        }
    }
}
