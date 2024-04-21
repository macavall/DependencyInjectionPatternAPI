namespace DependencyInjectionAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddTransient<IGreetingService, GreetingService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        public interface IGreetingService
        {
            string Greet(string name);
        }

        public class GreetingService : IGreetingService
        {
            public string Greet(string name)
            {
                return $"Hello, {name}!";
            }
        }
    }
}
