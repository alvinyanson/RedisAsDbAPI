using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisAsDbAPI.Data;
using RedisAsDbAPI.Models;

namespace RedisAsDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;

        public PlatformsController(IPlatformRepo platformRepo)
        {
            _platformRepo = platformRepo;
        }


        [HttpGet("{id}", Name = "GetPlatformById")]
        public IActionResult GetPlatformById(string id)
        {
            var platform = _platformRepo.GetPlatformById(id);

            if (platform != null)
            {
                return Ok(platform);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult GetPlatforms()
        {
            return Ok(_platformRepo.GetAllPlatforms());
        }


        [HttpPost]
        public IActionResult CreatePlatform(Platform platform)
        {
            _platformRepo.CreatePlatform(platform);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platform.Id }, platform);
        }
    }
}
