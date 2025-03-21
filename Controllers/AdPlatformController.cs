using Microsoft.AspNetCore.Mvc;
using MVC.Service;

namespace MVC.Controllers
{
    [ApiController]
    [Route("api/adplatforms")]
    public class AdPlatformController : ControllerBase
    {
        private readonly AddPlatformService _service = new();

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
