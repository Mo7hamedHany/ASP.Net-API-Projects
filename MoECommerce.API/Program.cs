using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoECommerce.API.Errors;
using MoECommerce.API.Extensions;
using MoECommerce.Core.Interfaces.Repositories;
using MoECommerce.Core.Interfaces.Services;
using MoECommerce.Core.Models.Identity;
using MoECommerce.Repository.Data.Contexts;
using MoECommerce.Repository.Data.DataSeeding;
using MoECommerce.Repository.Repositories;
using MoECommerce.Services;
using StackExchange.Redis;
using System.Reflection;

namespace MoECommerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddApplicationServices(builder.Configuration);

            builder.Services.AddIdentityService(builder.Configuration);

            builder.Services.AddSwagerService();

            var app = builder.Build();

           await DbInitializer.InitializeDbAsync(app);

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.UseMiddleware<CustomExceptionHandler>();

            app.Run();
        }

       
    }
}
