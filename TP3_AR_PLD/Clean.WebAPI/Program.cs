
using Microsoft.EntityFrameworkCore;
using Clean.WebAPI;
using Clean.Infrastructure;
using Clean.Core.Interfaces;
using Clean.Core.Services;
using Clean.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<CleanContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString(@"Server=.;Database=TP3DB;Trusted_Connection=True;")));

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // Add AutoMapper configuration
        builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        builder.Services.AddScoped<IBackEndSystemService, BackEndSystemService>();
        builder.Services.AddScoped<ICalculVersementsService, CalculVersementsService>();
        builder.Services.AddScoped<ICalculVersementsRepository, CalculVersementsRepository>();
        builder.Services.AddScoped<IDemandeAideFinancieresService, DemandeAideFiancieresService>();
        builder.Services.AddScoped<IDemandeAideFinancieresRepository, DemandeAideFinancieresRepository>();
        builder.Services.AddScoped<IDossierEtudiantsRepository, DossierEtudiantsRepository>();
        builder.Services.AddScoped<IDossierEtudiantsService, DossierEtudiantsService>();
        builder.Services.AddScoped<IEtudiantsRepository, EtudiantsRepository>();
        builder.Services.AddScoped<IEtudiantsService, EtudiantsService>();
        
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
        options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                    .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        
        var app = builder.Build();

        // Configure CORS
        app.UseCors(options =>
        {
            options.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });

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