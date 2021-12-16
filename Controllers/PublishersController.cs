using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOnlineBookStore.Data;

namespace TheOnlineBookStore.Controllers
{
    public class PublishersController : Controller
    {
        private readonly DatabaseContext _context;

        public PublishersController(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var AllPublishers = await _context.Publishers.ToListAsync();
            return View(AllPublishers);
        }
    }
}
