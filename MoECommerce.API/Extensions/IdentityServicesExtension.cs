using Microsoft.AspNetCore.Identity;
using MoECommerce.Core.Models.Identity;
using MoECommerce.Repository.Data.Contexts;

namespace MoECommerce.API.Extensions
{
    public static class IdentityServicesExtension
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddSignInManager<SignInManager<ApplicationUser>>();

            services.AddAuthentication();

            return services;
        }
    }
}
