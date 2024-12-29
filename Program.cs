using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Diagnostics;

namespace InventoryManagementAspNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Inventory API", Version = "v1" });
            });

            // Configure Entity Framework and SQL Server
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure()));

            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory API V1");
                    c.RoutePrefix = "swagger"; // Swagger for API documentation.
                });
            }

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Products}/{action=Index}/{id?}");

            // Launch Swagger and front-end on application startup
            var urlSwagger = "https://localhost:5002/swagger";
            var urlFrontend = "https://localhost:5002/Products/Index";

            // Ensure only one instance of the browser is launched
            if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") != "true")
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = urlSwagger,
                    UseShellExecute = true
                });

                Process.Start(new ProcessStartInfo
                {
                    FileName = urlFrontend,
                    UseShellExecute = true
                });
            }

            app.Run();
        }
    }
}