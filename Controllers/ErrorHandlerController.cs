using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorHandlerController : ControllerBase
    {
        private readonly ILogger _logger;

        public ErrorHandlerController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            int x = 10 / id;
            return Ok();
        }
    }
}
