namespace middleware_HW
{
    public class Aript_LogURLMiddleware
    {
        private  RequestDelegate _next;
        private  ILogger<Aript_LogURLMiddleware> _logger; //logger is used to display some log warning
        
        public Aript_LogURLMiddleware(RequestDelegate next, ILoggerFactory loggerFactory) //next is a RequestDelegate object that handles http requests
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<Aript_LogURLMiddleware>() ?? // ?? is null-coalescing operator
            throw new ArgumentNullException(nameof(loggerFactory));
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogWarning($"you are seeing request url:{Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
            await this._next(context);
        }
    }

    public static class Arpit_LogURLMiddlewareExtensions //extension method for IApplicationBuilder object
    {
        public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Aript_LogURLMiddleware>();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseLogUrl();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}