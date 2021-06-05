using Microsoft.AspNetCore.Mvc;
using CMSShoppingCart.Infrastructure;
using System.Threading.Tasks;
using System.Linq;
using CMSShoppingCart.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CMSShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly CmsShoppingCartContext _context;

        public PagesController(CmsShoppingCartContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in _context.Pages
                                     orderby p.Sorting
                                     select p;

            List<Page> pagesList = await pages.ToListAsync();

            return View(pagesList);
        }
    }
}
