using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DragRacing_Web.Areas.Identity.Data;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DragRacing_WebContextConnection") ?? throw new InvalidOperationException("Connection string 'DragRacing_WebContextConnection' not found.");

        builder.Services.AddDbContext<DragRacing_WebContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<DragRacing_WebUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DragRacing_WebContext>();

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

        app.MapRazorPages();

        app.Run();

    }
}
