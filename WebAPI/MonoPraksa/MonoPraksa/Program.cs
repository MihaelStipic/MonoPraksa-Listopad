using Microsoft.EntityFrameworkCore;
using MonoPraksa.Model;
using MonoPraksa.Repository;
using MonoPraksa.Repository.Common;
using MonoPraksa.Service;
using MonoPraksa.Service.Common;

namespace MonoPraksa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //builder.Services.AddTransient<IFootballerRepository, FootballerRepository>();
            //builder.Services.AddSingleton<IFootballerRepository, FootballerRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IFootballerRepository, FootballerRepository>();
            builder.Services.AddScoped<IFootballerService, FootballerService>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
