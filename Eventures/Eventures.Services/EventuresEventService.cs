using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventures.Services
{
    public class EventuresEventService : IEventService
    {
        private EventuresDbContext _context;

        public EventuresEventService(EventuresDbContext context)
        {
            this._context = context;
        }

        public async Task Create(EventuresEvent eventuresEvent)
        {
            _context.Add(eventuresEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventuresEvent>> GetAll()
        {
            return await _context.EventuresEvents.ToListAsync();
        }
    }
}