using EduHome.Core.Entities;

namespace EduHome.UI.ViewModel;

public class HomeVM
{
    public IEnumerable<Blog> Blogs { get; set; }
    public IEnumerable<Slider> Sliders { get; set; } 
    public IEnumerable<Course> Courses { get; set; } 
    public IEnumerable<CourseDetail> CourseDetails { get; set; } 
    public IEnumerable<CourseCatagory> CourseCatagorys { get; set; }
    public IEnumerable<NoticeBoard> NoticeBoard { get; set; }
    public IEnumerable<Event> Events { get; set; }
    public IEnumerable<Testimonial> Testimonials { get; set; }

}
