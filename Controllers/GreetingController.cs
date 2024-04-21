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
        private readonly IServiceProvider _serviceProvider;

        public GreetingController(IGreetingTransient greetingServiceTransient, IGreetingScoped greetingServiceScoped, IGreetingSingleton greetingServiceSingleton, IServiceProvider serviceProvider)
        {
            _greetingServiceTransient = greetingServiceTransient;
            _greetingServiceScoped = greetingServiceScoped;
            _greetingServiceSingleton = greetingServiceSingleton;
            _serviceProvider = serviceProvider;
        }

        [HttpGet("{name}")]
        public ActionResult<string> GetGreeting(string name)
        {
            // write simple switch statement to handle different types of greetings

            switch (name.ToLower())
            {

                case "transient":
                    {
                        var result = _serviceProvider.GetRequiredService<IGreetingTransient>().Greeting("Another Call using Transient");

                        return _greetingServiceTransient.Greeting($"\n\n\n{result}\n\n\n World from Transient");
                    }

                case "scoped":
                    {
                        var result = _serviceProvider.GetRequiredService<IGreetingScoped>().Greeting("Another Call using Scoped");

                        return _greetingServiceScoped.Greeting($"\n\n\n{result}\n\n\n World from Scoped");
                    }

                case "singleton":
                    {
                        var result = _serviceProvider.GetRequiredService<IGreetingSingleton>().Greeting("Another Call using Singleton");

                        return _greetingServiceSingleton.Greeting($"\n\n\n{result}\n\n\n World from Singleton");
                    }

                default:
                    return "Invalid Greeting Type\nPlease use one of the following:\nTransient\nScoped\nSingleton\n\nExamples:\n https://localhost:7071/greeting/transient\n https://localhost:7071/greeting/scoped\n https://localhost:7071/greeting/singleton";
            }
        }
    }
}
