using EduHome.Core.Entities;

namespace EduHome.UI.ViewModel;

public class HomeVM
{
    public IEnumerable<Blog> Blogs { get; set; }
    public IEnumerable<Slider> Sliders { get; set; }
}
