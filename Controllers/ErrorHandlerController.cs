using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorHandlerController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }
    }
}
