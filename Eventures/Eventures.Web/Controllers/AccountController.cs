using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventures.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _service;

        public AccountController(IUserService service)
        {
            this._service = service;
        }

        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            await this._service.Login(viewModel.Username, viewModel.RememberMe);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel viewModel)
        {
            var user = new EventuresUser
            {
                UserName = viewModel.Username,
                Email = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                UniqueCitizenNumber = viewModel.UniqueCitizenNumber
            };

            await _service.Create(user);
            return View("Login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this._service.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}