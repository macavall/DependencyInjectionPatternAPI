using Microsoft.AspNetCore.Mvc;
using static DependencyInjectionAPI.Program;

namespace DependencyInjectionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        private readonly IGreetingService _greetingService;

        public GreetingController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [HttpGet("{name}")]
        public ActionResult<string> GetGreeting(string name)
        {
            return _greetingService.Greet(name);
        }
    }
}
