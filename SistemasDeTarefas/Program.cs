using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Repositories;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionStringMysql = builder.Configuration.GetConnectionString("ConnectionMysql");
            builder.Services.AddDbContext<TaskSistemDBContext>(x => x.UseMySql(
                connectionStringMysql,
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31")
                )
            );
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}