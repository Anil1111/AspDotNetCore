using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Eventures.Services
{
    public class EventuresUserService : IUserService
    {
        private SignInManager<EventuresUser> _signInManager;
        private UserManager<EventuresUser> _userManager;

        public EventuresUserService(SignInManager<EventuresUser> signInManager, UserManager<EventuresUser> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        public async Task Create(EventuresUser user)
        {
            await _userManager.CreateAsync(user);
        }

        public async Task Login(string username, bool percist)
        {
            var user = await _userManager.FindByNameAsync(username);
            await _signInManager.SignInAsync(user, percist);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}