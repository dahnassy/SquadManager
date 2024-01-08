using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Context;

namespace API
{
    public class Program
    {
        public static void Main(string[] args )
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            

            addScope(builder.Services);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options => options.AddPolicy("MyPolicy", 
                builder => {
                    builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin();
                }
                ));

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

            app.UseCors(builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin());

            app.Run();

            
        }

        private static void addScope(IServiceCollection services)
        {
            
            services.AddDbContext<EFContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;DataBase=EFCore; Trusted_connection=True;"));

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}