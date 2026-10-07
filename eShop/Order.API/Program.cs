using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroservice.ApplicationCore.Services;
using OrderMicroservice.Infrastructure.Repositories;
using OrderMicroservice.Infrastructure.Services;
using OrderMicroservice.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;



namespace OrderMicroservice.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            builder.Services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();

            // Services
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
            builder.Services.AddScoped<IShoppingCartItemService, ShoppingCartItemService>();

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