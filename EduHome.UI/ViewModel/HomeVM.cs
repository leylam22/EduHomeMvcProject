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
    public IEnumerable<EventsDetail> EventsDetails { get; set; }
    public IEnumerable<EventSpeaker> EventSpeakers { get; set; }
    public IEnumerable<Speaker> Speakers { get; set; }
    public IEnumerable<Testimonial> Testimonials { get; set; }
    public IEnumerable<AboutUs> AboutUses { get; set; }
    public IEnumerable<Teacher> Teachers { get; set; }
    public IEnumerable<TeacherDetail> TeacherDetails { get; set; }


}
