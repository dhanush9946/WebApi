

using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello from .Net Core Web Api";
        }
    }
}