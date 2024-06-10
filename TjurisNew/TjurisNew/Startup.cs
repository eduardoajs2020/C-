using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TjurisNew
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); // Adiciona serviços para controladores

            // Configuração de CORS (Cross-Origin Resource Sharing)
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:8848", "http://localhost:5295") // Especifique origens permitidas
                           .AllowAnyMethod()   // Permite qualquer método HTTP
                           .AllowAnyHeader();  // Permite qualquer cabeçalho de solicitação
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Usa páginas de erro detalhadas no desenvolvimento
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // Configura página de erro padrão para produção
                app.UseHsts(); // Habilita HSTS para segurança em produção
            }

            app.UseHttpsRedirection(); // Redireciona HTTP para HTTPS
            app.UseStaticFiles(); // Serve arquivos estáticos como CSS, JS, etc.
            app.UseRouting(); // Habilita roteamento
            app.UseCors("AllowAllOrigins"); // Aplica a política de CORS

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Mapeia controladores para padrões de URL
            });
        }
    }
}
