using DragRacing_Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DragRacing_Web.Models;

namespace DragRacing_Web.Areas.Identity.Data;

public class DragRacing_WebContext : IdentityDbContext<DragRacing_WebUser>
{
    public DragRacing_WebContext(DbContextOptions<DragRacing_WebContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<DragRacing_Web.Models.Tracks> Tracks { get; set; } = default!;

    public DbSet<DragRacing_Web.Models.Engines> Engines { get; set; } = default!;

    public DbSet<DragRacing_Web.Models.Cars> Cars { get; set; } = default!;

    public DbSet<DragRacing_Web.Models.Drivers> Drivers { get; set; } = default!;

    public DbSet<DragRacing_Web.Models.Results> Results { get; set; } = default!;
}
