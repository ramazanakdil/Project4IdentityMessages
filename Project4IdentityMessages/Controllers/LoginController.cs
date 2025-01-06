using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project4IdentityMessages.Models;
using Project4IdentityMessages_EntityLayer.Concrete;

namespace Project4IdentityMessages.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Inbox", "Message");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}
