using CSWork21.Auth;
using CSWork21.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSWork21.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new UserLoginData() { ReturnUrl = returnUrl });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginData authData)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(
                    authData.UserName, 
                    authData.Password, 
                    false,
                    false);

                if (result.Succeeded)
                {
                    if (Url.IsLocalUrl(authData.ReturnUrl))
                        return Redirect(authData.ReturnUrl);

                    return RedirectToMainPage();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(authData);
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToMainPage();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserRegistrationData());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationData model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.UserName };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToMainPage();
                }
                else
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
            }
                
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        private RedirectToActionResult RedirectToMainPage()
        {
            return RedirectToAction("ContactsList", "PhoneBook");
        }
    }
}
