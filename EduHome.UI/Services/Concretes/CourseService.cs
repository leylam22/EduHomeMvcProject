using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.UI.Areas.Admin.ViewModels.CourseViewModel;
using EduHome.UI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.UI.Services.Concretes;

public class CourseService : ICourseService
{
    private readonly AppDbContext _context;

    public CourseService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateCourseAsync(CoursePostVM coursePostVM)
    {
        if (coursePostVM is null) return false;

        var languageOption = await _context.Languages.FindAsync(coursePostVM.LanguageOptionId);
        if (languageOption is null) return false;

        var assesment = await _context.Assesments.FindAsync(coursePostVM.AssesmentId);
        if(assesment is null) return false;

        var skillLevel = await _context.SkillLevels.FindAsync(coursePostVM.SkillLevelId);
        if (skillLevel is null) return false;

        var courseCatagory = await _context.CourseCatagories.FindAsync(coursePostVM.CourseCatagoryId);
        if (courseCatagory is null) return false;

        CourseDetail courseDetail = new()
        {
            Starts= coursePostVM.Start,
            Duration= coursePostVM.Duration,
            CourseFee= coursePostVM.CourseFee,
            ClassDuration= coursePostVM.ClassDuration,
            LanguageOption= languageOption,
            Skill= skillLevel,
            Assesment= assesment
        };

        await _context.CourseDetails.AddAsync(courseDetail);
        await _context.SaveChangesAsync();

        Course course = new()
        {
            Title = coursePostVM.Title,
            Description = coursePostVM.Description,
            ImagePath = coursePostVM.ImagePath,
            CourseCatagoryId = courseCatagory.Id,
            CourseDetailId= courseDetail.Id
        };

        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
        return true;
    }

    public Task<List<CourseVM>> GetAllCourseAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CourseDetailVM> GetCourseDetailByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
