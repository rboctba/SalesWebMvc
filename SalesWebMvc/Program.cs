using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Data;
using SalesWebMvc.Services;
using System.Globalization;

namespace SalesWebMvc
{
    internal class Program
    {

        private static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            builder.Services.AddDbContext<SalesWebMvcContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMvcContext"), serverVersion));

            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();
            builder.Services.AddScoped<SalesRecordService>();

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
            else
            {
                app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
            }

            var enUS = new CultureInfo("en-US");
            var localizationOption = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUS),
                SupportedCultures = new List<CultureInfo> { enUS },
                SupportedUICultures = new List<CultureInfo>() { enUS } 
            };

            app.UseRequestLocalization(localizationOption);

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