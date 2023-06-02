using Microsoft.EntityFrameworkCore;
using ProjectAPI.Context;
using ProjectAPI.Controllers;

namespace ProjectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<NSTDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnction"));

            });

                        builder.Services.AddEndpointsApiExplorer();

            // Add services to the container.

            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskApi");
            });
            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();


            app.Run();
        }
    }
}