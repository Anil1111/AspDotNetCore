using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CHUSHKA.Web.ViewModels;
using Chuska.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ChushkaUser> _userManager;
        private readonly SignInManager<ChushkaUser> _signInManager;

        public AccountController(SignInManager<ChushkaUser> signInManager, UserManager<ChushkaUser> userManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(model.Username, model.Password, true, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ChushkaUser
                {
                    UserName = viewModel.Username,
                    Email = viewModel.Email,
                    FullName = viewModel.FullName
                };

                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    string role = _userManager.Users.Count() == 1 ? "Administrator" : "User";

                    var addRole = _userManager
                        .AddToRoleAsync(user, role)
                        .Result;

                    if (addRole.Errors.Any())
                    {
                        ModelState.AddModelError("", "Invalid registration attempt");
                        return this.View();
                    }

                    return View("Login");
                }
            }

            ModelState.AddModelError("", "Invalid registration attempt");
            return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async Task<IActionResult> AddChushkaUser(ChushkaUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                string role = _userManager.Users.Count() == 1 ? "Admin" : "User";

                var addRole = _userManager
                    .AddToRoleAsync(user, role)
                    .Result;

                if (addRole.Errors.Any())
                {
                    ModelState.AddModelError("", "Invalid registration attempt");
                    return this.View();
                }

                // All good proceed with login
                return null;
            }

            ModelState.AddModelError("", "Invalid registration attempt");
            return this.View();
        }
    }
}