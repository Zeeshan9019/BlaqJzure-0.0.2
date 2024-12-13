using Autofac.Core;
using BlaqJzure.Domain.Users;
using BlaqJzure.Repository;
using BlaqJzure.Repository.IrepositoryServices;
using BlaqJzure.Repository.RepositryServices;
using BlaqJzure.Service.Interfaces;
using BlaqJzure.Service.Services;
using BlaqJzure.Web.Models;
using CrossSolution.DI.Registrars;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<ApplicationDbContext>(o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.SignIn.RequireConfirmedEmail = false; // Set to true if email confirmation is required
        })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
        });
        builder.Services.AddScoped<AouthFilter>();

        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
        builder.Services.AddScoped(typeof(Irepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IadminService, AdminService>();
        builder.Services.AddScoped<IuserService, UserService>();
        /*ServiceRegistrar serviceRegistrar = new DefaultRegistrar(builder.Services,
            [
                ("BlaqJzure.Service", ServiceLifetime.Scoped),
                ("BlaqJzure.Repository", ServiceLifetime.Scoped),
            ]);
        serviceRegistrar.Register();*/
        var app = builder.Build();

        await RoleSeeder.SeedRolesAsync(app.Services);

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseSession();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Dashboards}/{action=Index}/{id?}");

        app.Run();
    }
}