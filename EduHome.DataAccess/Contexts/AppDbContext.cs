using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHome.DataAccess.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Blog> Blogs { get; set; } = null!;
<<<<<<< HEAD
    public DbSet<Slider> Sliders { get; set; } = null!;
=======
>>>>>>> 83538c1a215db16639e5e0d75d974bbdc596408a
}
