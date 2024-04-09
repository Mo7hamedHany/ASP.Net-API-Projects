using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoECommerce.API.Errors;
using MoECommerce.Core.Interfaces.Repositories;
using MoECommerce.Core.Interfaces.Services;
using MoECommerce.Repository.Data.Contexts;
using MoECommerce.Repository.Data.DataSeeding;
using MoECommerce.Repository.Repositories;
using MoECommerce.Services;
using System.Reflection;

namespace MoECommerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DataContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnection")));

            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped<IProductService, ProductService>();
            
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.Configure<ApiBehaviorOptions>(options =>
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

            var app = builder.Build();

           await InitializeDbAsync(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseMiddleware<CustomExceptionHandler>();

            app.Run();
        }

        private static async Task InitializeDbAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;

                var loggerFactory = service.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = service.GetRequiredService<DataContext>();

                    if ((await context.Database.GetPendingMigrationsAsync()).Any())
                    {
                        await context.Database.MigrateAsync();
                    }

                    await DataContextSeed.SeedData(context);


                }
                catch (Exception ex)
                {

                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex.Message);
                }
            }
        }
    }
}
