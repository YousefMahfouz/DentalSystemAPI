
using DentialSystem.Application.Contract;
using DentialSystem.Application.Services;
using DentialSystem.Context;
using DentialSystem.Infrastracture;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DentalSystemApi
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
            builder.Services.AddScoped<IPaitantTreatmentReposatory, PaitantTreatmentReposatory>();
            builder.Services.AddScoped<IPaitantTreatmentServices, PaitantTreatmentServices>();
            builder.Services.AddScoped<ITreatmentReposatory, TreatmentReposatory>();
            builder.Services.AddScoped<ITreatmentServices, TreatmentServices>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
            });
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}