using System.ComponentModel.DataAnnotations;

namespace EduHome.UI.ViewModel.AuthViewModel;

public class ForgotPasswordModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
