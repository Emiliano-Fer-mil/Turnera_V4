using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turnera_V4.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Turnera_V4
{
        public class Program
        {
            public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);

                builder.Services.AddDbContext<TurneraBDContext>(
                  options => options.UseSqlServer(builder.Configuration["ConnectionString:TurneraBDConexion"]));

                // Add services to the container.
                builder.Services.AddControllersWithViews();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();
            }
        }
}
