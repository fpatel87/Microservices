using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.Infrastructure.Data;
using ShippingMicroservice.ApplicationCore.Repositories;
using ShippingMicroservice.ApplicationCore.Services;
using ShippingMicroservice.Infrastructure.Repositories;
using ShippingMicroservice.Infrastructure.Services;

namespace ShippingMicroservice.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ShippingDbContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("ShippingConnection")));

            builder.Services.AddScoped<IShipperRepository, ShipperRepository>();
            builder.Services.AddScoped<IShippingDetailsRepository, ShippingDetailsRepository>();
            builder.Services.AddScoped<IShipperService, ShipperService>();
            builder.Services.AddScoped<IShippingDetailsService, ShippingDetailsService>();

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