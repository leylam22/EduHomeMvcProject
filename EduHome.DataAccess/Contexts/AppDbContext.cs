using EduHome.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduHome.DataAccess.Contexts;

public class AppDbContext:IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<Slider> Sliders { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<CourseDetail> CourseDetails { get; set; } = null!;
    public DbSet<CourseCatagory> CourseCatagories { get; set; } = null!;
    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Assesment> Assesments { get; set; } = null!;
    public DbSet<SkillLevel> SkillLevels { get; set; } = null!;
    public DbSet<NoticeBoard> NoticeBoard { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Testimonial> Testimonials { get; set; } = null!;
    public DbSet<TeacherDetail> TeacherDetails { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;

}
