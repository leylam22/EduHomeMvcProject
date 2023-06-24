using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHome.DataAccess.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<Slider> Sliders { get; set; } = null!;
}
