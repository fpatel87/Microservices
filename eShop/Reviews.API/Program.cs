using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.Infrastructure.Data;
using ReviewsMicroservice.ApplicationCore.Repositories;
using ReviewsMicroservice.ApplicationCore.Services;
using ReviewsMicroservice.Infrastructure.Repositories;
using ReviewsMicroservice.Infrastructure.Services;


namespace ReviewsMicroservice.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ReviewsDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("ReviewsConnection")));

            builder.Services.AddScoped<ICustomerReviewRepository, CustomerReviewRepository>();
            builder.Services.AddScoped<ICustomerReviewService, CustomerReviewService>();

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