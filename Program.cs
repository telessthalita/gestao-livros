using Microsoft.EntityFrameworkCore;
using WebApi_Livros.Data;
using WebApi_Livros.Services.Autor;
using Microsoft.OpenApi.Models;
using WebApi_Livros.Services.Livro;

namespace WebApi_Livros
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();
            // Configuração do DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Injeção de dependência
            builder.Services.AddScoped<IAutorInterface, AutorService>();
            builder.Services.AddScoped<ILivroInterface, LivroService>();

            // Configuração do Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API de Livros",
                    Version = "v1",
                    Description = "Uma API para gerenciar livros e autores",
                });
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            else
            {
                // Ativar o middleware do Swagger apenas em desenvolvimento
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Livros v1");
                    c.RoutePrefix = string.Empty; 
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.MapRazorPages();

            app.Run();
        }
    }
}
