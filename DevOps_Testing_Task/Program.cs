
using DevOps_Testing_Task.Data;
using DevOps_Testing_Task.Repositories.Abstracts;
using DevOps_Testing_Task.Repositories.Concretes;
using DevOps_Testing_Task.Services.Abstracts;
using DevOps_Testing_Task.Services.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DevOps_Testing_Task
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

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            var conn = builder.Configuration.GetConnectionString("Connection");

            builder.Services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(conn);
            });

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
