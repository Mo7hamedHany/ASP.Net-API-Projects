using MoECommerce.Core.Models.Order;
using MoECommerce.Core.Models.Product;
using MoECommerce.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoECommerce.Repository.Data.DataSeeding
{
    public static class DataContextSeed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Set<ProductBrand>().Any())
            {

                var brandsData = await File.ReadAllTextAsync("../MoECommerce.Repository/Data/DataSeeding/brands.json");

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                if (brands != null && brands.Any() ) 
                {
                    await context.Set<ProductBrand>().AddRangeAsync(brands);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Set<ProductType>().Any())
            {

                var TypesData = await File.ReadAllTextAsync("../MoECommerce.Repository/Data/DataSeeding/types.json");

                var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                if (Types != null && Types.Any())
                {
                    await context.Set<ProductType>().AddRangeAsync(Types);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Set<Product>().Any())
            {

                var productsData = await File.ReadAllTextAsync("../MoECommerce.Repository/Data/DataSeeding/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products != null && products.Any())
                {
                    await context.Set<Product>().AddRangeAsync(products);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Set<DeliveryMethods>().Any())
            {

                var deliverData = await File.ReadAllTextAsync("../MoECommerce.Repository/Data/DataSeeding/delivery.json");

                var deliveries = JsonSerializer.Deserialize<List<DeliveryMethods>>(deliverData);

                if (deliveries != null && deliveries.Any())
                {
                    await context.Set<DeliveryMethods>().AddRangeAsync(deliveries);
                    await context.SaveChangesAsync();
                }
            }

        }
    }
}
