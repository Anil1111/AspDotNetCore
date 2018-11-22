using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Web.Filters;
using Eventures.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.Controllers
{
    [Authorize]
    public class EventuresEventsController : Controller
    {
        private readonly IEventService _service;
        private readonly ILogger<EventuresEventsController> _logger;

        public EventuresEventsController(IEventService service, ILogger<EventuresEventsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [ServiceFilter(typeof(CreateEventFilter))]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventuresEventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var eventuresEvent = new EventuresEvent
                {
                    Name = viewModel.Name,
                    Place = viewModel.Place,
                    Start = viewModel.Start,
                    End = viewModel.End,
                    TotalTickets = viewModel.TotalTickets,
                    TicketPrice = viewModel.TotalTickets
                };

                await _service.Create(eventuresEvent);
                this._logger.LogInformation($"Event created: {eventuresEvent.Name}");
                ViewData["eventName"] = eventuresEvent.Name;
                return RedirectToAction("Index", "EventuresEvents");
            }

            return View(viewModel);
        }
    }
}