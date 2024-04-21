using Microsoft.AspNetCore.Mvc;
using static DependencyInjectionAPI.Program;

namespace DependencyInjectionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        private readonly IGreetingTransient _greetingServiceTransient;
        private readonly IGreetingScoped _greetingServiceScoped;
        private readonly IGreetingSingleton _greetingServiceSingleton;

        public GreetingController(IGreetingTransient greetingServiceTransient, IGreetingScoped greetingServiceScoped, IGreetingSingleton greetingServiceSingleton)
        {
            _greetingServiceTransient = greetingServiceTransient;
            _greetingServiceScoped = greetingServiceScoped;
            _greetingServiceSingleton = greetingServiceSingleton;
        }

        [HttpGet("{name}")]
        public ActionResult<string> GetGreeting(string name)
        {
            // write simple switch statement to handle different types of greetings

            switch (name.ToLower())
            {
                
                case "transient":

                    return _greetingServiceTransient.Greeting("World from Transient");
                 
                case "scoped":
                    return _greetingServiceScoped.Greeting("World from Scoped");

                case "singleton":
                    return _greetingServiceSingleton.Greeting("World from Singleton");

                 default:
                    return "Invalid Greeting Type\nPlease use one of the following:\nTransient\nScoped\nSingleton";
            }
        }
    }
}
