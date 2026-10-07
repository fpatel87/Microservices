using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.Infrastructure.Data;
using PromotionsMicroservice.ApplicationCore.Repositories;
using PromotionsMicroservice.ApplicationCore.Services;
using PromotionsMicroservice.Infrastructure.Repositories;
using PromotionsMicroservice.Infrastructure.Services;


namespace Promotions.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PromotionsDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("PromotionsConnection")));

            builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
            builder.Services.AddScoped<IPromotionService, PromotionService>();


            builder.Services.AddControllers();
           

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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