
using DentialSystem.Application.Contract;
using DentialSystem.Application.Services;
using DentialSystem.Application.Services.AppointmentService;
using DentialSystem.Context;
using DentialSystem.Domain;
using DentialSystem.Infrastracture;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using DentialSystem.Application.Services.DentalService;

namespace DentalSystemApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Add services to the container.
            builder.Services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().SetIsOriginAllowed(origin => origin == "https://member5-8.smarterasp.net/cp/filemanager.asp?d=h:"); ;
                });
            });

            builder.Services.AddControllers().AddJsonOptions(op =>
            {
                op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IPaitantTreatmentReposatory, PaitantTreatmentReposatory>();
            builder.Services.AddScoped<IPaitantTreatmentServices, PaitantTreatmentServices>();
            builder.Services.AddScoped<ITreatmentReposatory, TreatmentReposatory>();
            builder.Services.AddScoped<ITreatmentServices, TreatmentServices>();
            builder.Services.AddScoped<IAppointmentReposatory, AppointmentReposatory>();
            builder.Services.AddScoped<IAppointmentServices, AppointmentServices>();
            builder.Services.AddScoped<IDentalHistoryServices, DentalHistoryServices>();
            builder.Services.AddScoped<IDentialHistoryReposatory, DentalHistoryReposatory>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("SecretKey").Value);
            builder.Services.AddAuthentication().AddJwtBearer(options =>
            {
                options.SaveToken = true;
                TokenValidationParameters token = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
            });
           builder.Services.AddIdentity<Paitant, IdentityRole>()
         .AddEntityFrameworkStores<ApplicationContext>()
         .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Configure antiforgery token options if needed
            });




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}