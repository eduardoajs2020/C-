using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ProjTJurisBackend;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(); // Adds services for controllers

        // Configure CORS (Cross-Origin Resource Sharing) - Potentially Insecure
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.WithOrigins("http://localhost:32239", "http://localhost:5025", "*")
                       .AllowAnyOrigin()  // Allow requests from any origin (Insecure)
                       .AllowAnyMethod()  // Allow any HTTP method
                       .AllowAnyHeader(); // Allow any request header
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage(); // Use detailed error pages in development
        }

        app.UseRouting();                   // Enable routing
        app.UseCors("AllowAllOrigins");     // Apply the CORS policy
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();     // Map controllers to URL patterns
        });
    }
}
    

