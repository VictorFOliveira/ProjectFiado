using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectFiado.Data;
using ProjectFiado.Mapper;
using ProjectFiado.Repository;
using ProjectFiado.Repository.Interfaces;
using ProjectFiado.Repository.Repository.Interfaces;
using ProjectFiado.Repository.Repository;
using ProjectFiado.Services;
using Serilog;
using System.Text;

namespace ProjectFiado
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\logs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Iniciando a aplicação");
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddScoped<ProductService>();
                builder.Services.AddScoped<ProductMapper>();
                builder.Services.AddScoped<IProduct, ProductRepository>();

                builder.Services.AddScoped<StockService>();
                builder.Services.AddScoped<StockMapper>();
                builder.Services.AddScoped<IStock, StockRepository>();

                builder.Services.AddScoped<IUser, UserRepository>();
                builder.Services.AddControllersWithViews();

                // Configuração da autenticação JWT
                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

                // Configuração do CORS
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowAllOrigins",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                        });
                });

                // Configuração do MySQL
                builder.Services.AddDbContext<FiadoDBContext>(options =>
                    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseRouting();
                app.UseCors("AllowAllOrigins");
                app.UseAuthentication();
                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "A aplicação terminou de forma inesperada");
                throw ex;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
