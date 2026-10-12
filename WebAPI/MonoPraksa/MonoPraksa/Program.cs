using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

            var jwtKey = builder.Configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("Jwt:Key is not configured.");
            
            var jwtIssuer = builder.Configuration["Jwt:Issuer"]
                ?? throw new InvalidOperationException("Jwt:Issuer is not configured.");
            var jwtAudience = builder.Configuration["Jwt:Audience"]
                ?? throw new InvalidOperationException("Jwt:Audience is not configured.");

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();


            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IFootballerRepository, FootballerRepository>();
            builder.Services.AddScoped<IFootballerService, FootballerService>();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            //Zato što [Authorize] sam po sebi ne zna kako provjeriti tko si.
            //kad stigne token, provjeri mu potpis mojim tajnim ključem i odbij ga ako je istekao
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                        //Je li token izdao MonoPraksa? (Issuer)
                        ValidateIssuer = true,
                        ValidIssuer = jwtIssuer,
                        //Je li namijenjen MonoPraksaUsers? (Audience)
                        ValidateAudience = true,
                        ValidAudience = jwtAudience,
                        ValidateLifetime = true
                    };
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}