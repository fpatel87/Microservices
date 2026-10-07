using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ProductMicroservice.ApplicationCore.Repositories;
using ProductMicroservice.ApplicationCore.Services;
using ProductMicroservice.Infrastructure.Data;
using ProductMicroservice.Infrastructure.Repositories;

namespace ProductMicroservice.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler =
                        ReferenceHandler.IgnoreCycles;
                });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString(
                        "DefaultConnection"
                    )
                );
            });

            builder.Services.AddScoped<
                ICategoryRepository,
                CategoryRepository
            >();

            builder.Services.AddScoped<
                ICategoryService,
                CategoryService
            >();

            builder.Services.AddScoped<
                ICategoryVariationRepository,
                CategoryVariationRepository
            >();

            builder.Services.AddScoped<
                ICategoryVariationService,
                CategoryVariationService
            >();

            builder.Services.AddScoped<
                IVariationValueRepository,
                VariationValueRepository
            >();

            builder.Services.AddScoped<
                IVariationValueService,
                VariationValueService
            >();

            builder.Services.AddScoped<
                IProductVariationRepository,
                ProductVariationRepository
            >();

            builder.Services.AddScoped<
                IProductVariationService,
                ProductVariationService
            >();

            builder.Services.AddScoped<
                IProductRepository,
                ProductRepository
            >();

            builder.Services.AddScoped<
                IProductService,
                ProductService
            >();

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