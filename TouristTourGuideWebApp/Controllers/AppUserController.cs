using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.ViewModels.AppUserViewModels;
using static TouristTourGuide.Common.NotificationMessage;
namespace TouristTourGuideWebApp.Controllers
{
    public class AppUserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;

        public AppUserController(SignInManager<ApplicationUser> sM,UserManager<ApplicationUser> usM,IUserStore<ApplicationUser>uS)
        {
            this._userManager = usM;
            this._signInManager  = sM;
            this._userStore = uS;    
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormViewModel registerViewModel) 
        {
            if (!ModelState.IsValid) 
            {
                return this.View(registerViewModel);
            }

            ApplicationUser apU = new ApplicationUser()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName                              
            };

            await this._userManager.SetEmailAsync(apU, registerViewModel.Email);
            await this._userManager.SetUserNameAsync(apU, registerViewModel.Email);
            IdentityResult result =  await this._userManager.CreateAsync(apU,registerViewModel.Password);
            
            if (!result.Succeeded) 
            {
                foreach (IdentityError error in result.Errors) 
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            await this._signInManager.SignInAsync(apU, isPersistent: false);
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public  IActionResult LogIn(string? returnUrl = null) 
        {
            HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            LoginFormViewModel loginForm = new LoginFormViewModel() 
            {
               ReturnUrl = returnUrl
            };
            return  View(loginForm);
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginFormViewModel loginForm) 
        {
            if (!ModelState.IsValid) 
            {
                return View(loginForm);
            }
            var result =
           await this._signInManager.PasswordSignInAsync(loginForm.Email, loginForm.Password, isPersistent: false,lockoutOnFailure:false); ;
            
            if (!result.Succeeded) 
            {
                TempData[ErrorMassage] = "Error with logging! Plase try again leter or contact an administrator"; 
                return View(loginForm);
            }
            return Redirect(loginForm.ReturnUrl ?? "/Home/Index");
        }
        
    }
}
