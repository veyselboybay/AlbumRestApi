using Microsoft.AspNetCore.Mvc;

namespace AlbumRestApi.Controllers
{
    [ApiController]
    public abstract class BaseController<T> : Controller
    {
        protected readonly ILogger<T> _logger;
        protected BaseController(ILogger<T> logger) {
            _logger= logger;
        }
    }
}
