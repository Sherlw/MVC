using Microsoft.AspNetCore.Mvc;
using MVC.Service;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly AddPlatformService _service = new();

        public IActionResult Index()
        {
            return Ok("Welcome to the platform API");
        }

        [HttpPost("upload")]
        public IActionResult UploadPlatforms([FromBody] string[] lines)
        {
            _service.LoadPlatforms(lines);
            return Ok("Data uploaded successfully");
        }

        [HttpGet("search")]
        public IActionResult SearchPlatforms([FromQuery] string location)
        {
            if (string.IsNullOrWhiteSpace(location)) return BadRequest("Location is required");
            var result = _service.FindPlatforms(location);
            return Ok(result);
        }
    }
}
