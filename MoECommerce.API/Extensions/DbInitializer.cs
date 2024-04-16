using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoECommerce.Core.Models.Identity;
using MoECommerce.Repository.Data.Contexts;
using MoECommerce.Repository.Data.DataSeeding;

namespace MoECommerce.API.Extensions
{
    public static class DbInitializer
    {
        public static async Task InitializeDbAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;

                var loggerFactory = service.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = service.GetRequiredService<DataContext>();

                    var identityContext = service.GetRequiredService<UserManager<ApplicationUser>>();

                    if ((await context.Database.GetPendingMigrationsAsync()).Any())
                    {
                        await context.Database.MigrateAsync();
                    }

                    await DataContextSeed.SeedData(context);

                    await IdentityDataContextSeed.SeedUserAsync(identityContext);


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
