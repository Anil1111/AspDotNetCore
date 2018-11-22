using Eventures.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.Middlewares
{
    public class SeedDbMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RoleManager<IdentityRole> _roleManager;
        private UserManager<EventuresUser> _userManager;

        public SeedDbMiddleware(RequestDelegate next, RoleManager<IdentityRole> roleManager, UserManager<EventuresUser> userManager)
        {
            this._next = next;
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (_userManager.Users.Count() == 0)
            {
                var admin = new EventuresUser
                {
                    UserName = "admin",
                    Email = "admin@abv.bg",
                    FirstName = "admin",
                    LastName = "admin",
                    UniqueCitizenNumber = "admin"
                };
                await _userManager.CreateAsync(admin, "admin");
                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            await _next(context);
        }
    }
}