using System.ComponentModel.DataAnnotations;

namespace EduHome.UI.Areas.Admin.ViewModels.BlogViewModel;

public class BlogPostVM
{
    [Required, StringLength(250)]
    public string Image { get; set; } = null!;
    [Required, StringLength(50)]
    public string Blogger { get; set; } = null!;
    public DateTime Date { get; set; }
    [Required, StringLength(250)]
    public string Title { get; set; } = null!;
}
