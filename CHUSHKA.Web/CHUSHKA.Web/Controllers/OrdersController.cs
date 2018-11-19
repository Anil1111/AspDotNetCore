using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHUSHKA.Data;
using Chushka.Models;
using Chuska.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CHUSHKA.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ChushkaDbContext _context;
        private readonly UserManager<ChushkaUser> _userManager;

        public OrdersController(ChushkaDbContext context, UserManager<ChushkaUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Orders
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            var chushkaDbContext = _context.Orders.Include(o => o.Product).Include(o => o.Client);
            return View(await chushkaDbContext.ToListAsync());
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        public async Task<IActionResult> Create(string id)
        {
            var product = await _context
                .Products
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var client = _context.Users.FirstOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var order = new Order()
            {
                Client = client,
                Product = product,
                ProductId = product.Id,
                OrderedOn = DateTime.Now
            };

            _context.Add(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Product");
        }

        private bool OrderExists(string id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}