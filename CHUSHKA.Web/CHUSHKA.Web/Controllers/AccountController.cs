using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CHUSHKA.Web.ViewModels;
using Chuska.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ChushkaUser> userManager;
        private readonly SignInManager<ChushkaUser> signInManager;

        public AccountController(SignInManager<ChushkaUser> signInManager, UserManager<ChushkaUser> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            var result = this.signInManager
                .PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false)
                .Result;

            if (result.Succeeded)
            {
                return this.RedirectToAction("Index", "Product");
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return this.View(viewModel);
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            var user = new ChushkaUser()
            {
                Email = viewModel.Email,
                UserName = viewModel.Username,
                FullName = viewModel.FullName,
            };

            var createUserResult = userManager.CreateAsync(user, viewModel.Password).Result;
            if (createUserResult.Succeeded)
            {
                if (userManager.Users.Count() == 1)
                {
                    var adminUserResult = userManager
                        .AddToRoleAsync(user, "Administrator")
                        .Result;
                    if (!adminUserResult.Errors.Any())
                    {
                        ModelState.AddModelError("", "Invalid login attempt");
                        return this.View(viewModel);
                    }
                }

                return this.RedirectToAction("Index", "Product");
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return this.View(viewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}