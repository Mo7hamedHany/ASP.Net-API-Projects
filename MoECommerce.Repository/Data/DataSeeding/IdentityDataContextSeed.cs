using Microsoft.AspNetCore.Identity;
using MoECommerce.Core.Models.Identity;

namespace MoECommerce.Repository.Data.DataSeeding
{
    public class IdentityDataContextSeed
    {
        public static async Task SeedUserAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = "MohamedHany",
                    Email = "hanykasim.tawfik@gmail.com",
                    DisplayName = "Mohamed Hany",
                    Address = new Address
                    {
                        City = "Cairo",
                        Country = "Egypt",
                        State = "New Cairo",
                        Street = "29 Avenue",
                        PostalCode = "12345"
                    }
                };
                await userManager.CreateAsync(user, "P@ssw0rd12345");
            }
        }
        
    }

}

