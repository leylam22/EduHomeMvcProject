﻿using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHome.DataAccess.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<Slider> Sliders { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<CourseCatagory> CourseCatagories { get; set; } = null!;
    public DbSet<NoticeBoard> NoticeBoard { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Testimonial> Testimonials { get; set; } = null!;
    public DbSet<TeacherDetail> TeacherDetails { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;

}
