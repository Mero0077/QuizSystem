
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuizSystem.Data;
using QuizSystem.DTOs.Course;
using QuizSystem.Models;
using QuizSystem.Repositories;
using System.Text;

namespace QuizSystem
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

            // Add DbContext
            builder.Services.AddDbContext<ApplicationdbContext>();

            //// Add Identity
            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationdbContext>()
            //    .AddDefaultTokenProviders();

            //// JWT Configuration
            //var jwtoptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
            //builder.Services.AddSingleton(jwtoptions);

            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.SaveToken = true;
            //    options.RequireHttpsMetadata = false;
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true,
            //        ValidIssuer = jwtoptions.Issuer,
            //        ValidateAudience = true,
            //        ValidAudience = jwtoptions.Audience,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SigninKey)),
            //        NameClaimType = "nameid"
            //    };
            //});
            builder.Services.AddAutoMapper(typeof(CourseProfile).Assembly);
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
