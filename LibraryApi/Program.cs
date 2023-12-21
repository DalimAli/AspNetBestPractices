using LibraryApi.Context;
using LibraryApi.Handler;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LibraryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var services = builder.Services;
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.LogTo(x => Console.WriteLine(x));
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            builder.Services.AddRateLimiter(o => o
            .AddFixedWindowLimiter(policyName: "fixed", options =>
            {
                options.PermitLimit = 1;
                options.Window = TimeSpan.FromSeconds(100);
            }));

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseExceptionHandler(opt => { });

            app.UseRateLimiter();

            // Configure the HTTP request pipeline.
            var title = "Library API";
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = $"{title}";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{title} documentation");
            });

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();


            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
