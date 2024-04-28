using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoECommerce.API.Errors;
using MoECommerce.Core.Interfaces.Repositories;
using MoECommerce.Core.Interfaces.Services;
using MoECommerce.Repository.Data.Contexts;
using MoECommerce.Repository.Repositories;
using MoECommerce.Services;
using StackExchange.Redis;
using System.Reflection;

namespace MoECommerce.API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

           services.AddDbContext<DataContext>(o => o.UseSqlServer(configuration.GetConnectionString("sqlconnection")));
           
           services.AddDbContext<IdentityDataContext>(o => o.UseSqlServer(configuration.GetConnectionString("IdentitySqlConnection")));
           
           services.AddControllers();


            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IBasketRepository, BasketRepository>();
            
            services.AddScoped<IBasketService, BasketService>();
            
            services.AddScoped<ICashService, CashService>();

            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IOrderService,  OrderService>();
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddSingleton<IConnectionMultiplexer>(options =>
            {
                var config = ConfigurationOptions.Parse(configuration.GetConnectionString("RedisConnection"));

                return ConnectionMultiplexer.Connect(config);
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Where(model => model.Value.Errors.Any())
                    .SelectMany(model => model.Value.Errors).Select(model => model.ErrorMessage).ToList();

                    return new BadRequestObjectResult(new ApiValidationError()
                    {
                        Errors = errors
                    });
                };
            });

            return services;
        }
    }
}
