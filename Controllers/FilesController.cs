using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfoAPI.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider; // maps extensions to MIME (Multipurpose Internet Media Extensions)
        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider)); // Null coalescing operator
        }
        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var pathToFile = "2024-04-03 18_36_14-Your Profile _ Multiverse Platform.png";

            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            if (!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType)) // out => assigns a value to contentType
            {
                contentType = "application/octet-stream"; //default media type for arbitrary binary data
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }

        [HttpPost]
        public async Task<ActionResult> CreateFile(IFormFile file)
        {
            //validation; prevents DDoS.
            if (file.Length == 0 || file.Length > 20971520
                || file.ContentType != "application/pdf")
            {
                return BadRequest("File either does not exist or is invalid.");
            }

            //Avoid using file.Filename as can be faked.
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                $"uploaded_file_{Guid.NewGuid()}.pdf"); // changes name of file. Globally Unique ID

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok("File has been uploaded successfully.");
        }

    }
}