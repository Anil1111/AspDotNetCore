using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace Eventures.Web.Filters
{
    public class CreateEventFilter : ActionFilterAttribute
    {
        private ILogger _logger;

        public CreateEventFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("CreateEventFilter");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var eventName = (context.Controller as Controller).ViewData["eventName"];
            var adminName = context.HttpContext.User.Identity.Name;
            this._logger.LogInformation($"[{DateTime.Now}] Administrator {adminName} create event {eventName}");
            base.OnActionExecuted(context);
        }
    }
}