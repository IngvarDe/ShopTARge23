using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.Core.Domain;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;


namespace ShopTARge23
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ISpaceshipsServices, SpaceshipsServices>();
            builder.Services.AddScoped<IFileServices, FileServices>();
            builder.Services.AddScoped<IRealEstateServices, RealEstateServices>();
            builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();
            builder.Services.AddScoped<IChuckNorrisServices, ChuckNorrisServices>();
            builder.Services.AddScoped<IFreeToGamesServices, FreeToGamesServices>();
            builder.Services.AddScoped<IFreeToGamesServices, FreeToGamesServices>();
            builder.Services.AddScoped<ICocktailServices, CocktailServices>();
            builder.Services.AddScoped<IEmailServices, EmailServices>();


            builder.Services.AddDbContext<ShopTARge23Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 3;

                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
                options.Lockout.MaxFailedAccessAttempts = 2;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddEntityFrameworkStores<ShopTARge23Context>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmation")
            .AddDefaultUI();

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

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider
                (Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
                RequestPath = "/multipleFileUpload"
            });

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
