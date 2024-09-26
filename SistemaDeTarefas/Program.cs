using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Repositorios;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SistemaTarefasDBContext>(options =>
                options.UseMySQL(connectionString));

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();
            builder.Services.AddScoped<ITipoAtividadeRepositorio, TipoAtividadeRepositorio>();
            builder.Services.AddScoped<ILocalAtividadeRepositorio, LocalAtividadeRepositorio>();
            builder.Services.AddScoped<IAtividadeRepositorio, AtividadeRepositorio>(); 
            builder.Services.AddScoped<IPostRepositorio, PostRepositorio>();

            builder.Services.AddControllers();

            // Swagger setup
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Enable Swagger for all environments (production included)
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaDeTarefas API v1");
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Any specific development configurations can go here
            }

            //app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
