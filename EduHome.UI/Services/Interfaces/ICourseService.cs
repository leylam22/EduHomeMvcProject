using EduHome.UI.Areas.Admin.ViewModels.CourseViewModel;

namespace EduHome.UI.Services.Interfaces
{
    public interface ICourseService
    {
        Task<bool> CreateCourseAsync(CoursePostVM coursePostVM);
        Task<CourseDetailVM> GetCourseDetailByIdAsync(int id);
        Task<List<CourseVM>> GetAllCourseAsync();
    }
}
