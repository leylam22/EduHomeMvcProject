using System.ComponentModel.DataAnnotations;

namespace EduHome.UI.Areas.Admin.ViewModels.SliderViewModel;

public class SliderPostVM
{
    [Required, StringLength(50)]
    public string SecondTitle { get; set; } = null!;
    [Required, StringLength(100)]
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    [Required, StringLength(250)]
    public string Image { get; set; } = null!;
}
