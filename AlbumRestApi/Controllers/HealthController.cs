using Microsoft.AspNetCore.Mvc;

namespace AlbumRestApi.Controllers
{
    [Route("health")]
    public class HealthController : BaseController<HealthController>
    {
        public HealthController(ILogger<HealthController> logger) : base(logger)
        {
        }

        [HttpGet]
        public IActionResult Health()
        {
            return Ok("Healthy");
        }
    }
}
