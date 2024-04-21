using System.Xml;

namespace DependencyInjectionAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddTransient<IGreetingTransient, GreetingServiceTransient>();
            builder.Services.AddTransient<IGreetingScoped, GreetingServiceScoped>();
            builder.Services.AddSingleton<IGreetingSingleton, GreetingServiceSingleton>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        public interface IGreetingTransient
        {
            public string Greeting(string name);
            public int GetCount();
        }

        public interface IGreetingScoped
        {
            public string Greeting(string name);
            public int GetCount();
        }

        public interface IGreetingSingleton
        {
            public string Greeting(string name);
            public int GetCount();
        }

        public class GreetingServiceTransient : IGreetingTransient
        {
            private int _count = 0;
            private string _uniqueId;

            public GreetingServiceTransient()
            {
                _uniqueId = Guid.NewGuid().ToString();
            }

            public string Greeting(string name)
            {
                _count++;
                return $"Hello, {name}! \n Count: {GetCount()}\nUniqueId: {_uniqueId}";
            }

            public int GetCount()
            {
                return _count;
            }
        }

        public class GreetingServiceScoped : IGreetingScoped
        {
            private int _count = 0;
            private string _uniqueId;

            public GreetingServiceScoped()
            {
                _uniqueId = Guid.NewGuid().ToString();
            }

            public string Greeting(string name)
            {
                _count++;
                return $"Hello, {name}! \n Count: {GetCount()}\nUniqueId: {_uniqueId}";
            }

            public int GetCount()
            {
                return _count;
            }
        }

        public class GreetingServiceSingleton : IGreetingSingleton
        {
            private int _count = 0;
            private string _uniqueId;

            public GreetingServiceSingleton()
            {
                _uniqueId = Guid.NewGuid().ToString();
            }

            public string Greeting(string name)
            {
                _count++;
                return $"Hello, {name}! \n Count: {GetCount()}\nUniqueId: {_uniqueId}";
            }

            public int GetCount()
            {
                return _count;
            }
        }
    }
}
