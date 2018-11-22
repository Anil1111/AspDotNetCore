using Eventures.Models;
using System.Threading.Tasks;

namespace Eventures.Services.Contracts
{
    public interface IUserService
    {
        Task Create(EventuresUser user);

        Task Login(string username, bool percist);

        Task Logout();
    }
}