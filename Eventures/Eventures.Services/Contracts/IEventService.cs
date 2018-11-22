using Eventures.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventures.Services.Contracts
{
    public interface IEventService
    {
        Task Create(EventuresEvent eventuresEvent);

        Task<IEnumerable<EventuresEvent>> GetAll();
    }
}