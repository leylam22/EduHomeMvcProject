using EduHome.Core.Entities;
using EduHome.UI.ViewModel.AuthViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace EduHome.UI.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
 
    public async Task<IActionResult> Register(RegisterVM newUser)
    {
        if (!ModelState.IsValid)
        {
            return View(newUser);
        }
        AppUser user = new()
        {
            Fullname= newUser.Username,
            Email= newUser.Email,
            UserName= newUser.Username
        };
        IdentityResult result = await _userManager.CreateAsync(user);
        if (result.Succeeded)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
        return RedirectToAction(nameof(LogIn));
    }

    public IActionResult LogIn()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> LogIn(LogInVM logIn)
    {
        if (!ModelState.IsValid) return View(logIn);
        AppUser user = await _userManager.FindByEmailAsync(logIn.UserNameOrEmail);
        if (user == null)
        {
            ModelState.AddModelError("", "Login ve ya parol yalnishdir");
            return View(logIn);
        }
        if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Email))
        {
            return NotFound();
        }
        Microsoft.AspNetCore.Identity.SignInResult result = await
        _signInManager.PasswordSignInAsync(user, logIn.Password, logIn.RememberMe, true);
        if (result.IsLockedOut)
        {
            ModelState.AddModelError("", "Your account is locked. Try it later");
            return View(logIn);
        }
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Login ve ya parol yalnishdir");
            return View(logIn);
        }

        return RedirectToAction("Home", "Index" , new {area="Admin"});
    }

    public async Task<IActionResult> LogOut()
    {
        if (User.Identity.IsAuthenticated)
        {
            await _signInManager.SignOutAsync();
        }
        return RedirectToAction("Index", "Home");
    }

    #region Create Role
    //public async Task CreateRole()
    //{
    //    foreach (var role in Enum.GetValues(typeof(UserRole.Roles)))
    //    {
    //        bool isExsist = await _roleManager.RoleExistsAsync(role.ToString());
    //        if (!isExsist)
    //        {
    //            await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
    //        }
    //    }
    //}
    #endregion
}