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

        // GET /admin/pages
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in _context.Pages
                                     orderby p.Sorting
                                     select p;

            List<Page> pagesList = await pages.ToListAsync();

            return View(pagesList);
        }

        // GET /admin/pages/details/id
        public async Task<IActionResult> Details(int id)
        {
            Page page = await _context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            if(page == null) { return NotFound(); }

            return View(page);
        }

        // GET /admin/pages/create
        public IActionResult Create() => View();

        // POST /admin/pages/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var slug = await _context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null) { ModelState.AddModelError("", "The title already exists."); return View(page); }

                _context.Add(page);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The page has been added!";
                return RedirectToAction("Index");
            }

            return View(page);
        }

        // GET /admin/pages/edit/id
        public async Task<IActionResult> Edit(int id)
        {
            Page page = await _context.Pages.FindAsync(id);
            if (page == null) { return NotFound(); }

            return View(page);
        }

        // POST /admin/pages/edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Id == 1 ? "home" : page.Title.ToLower().Replace(" ", "-");

                var slug = await _context.Pages.Where(x => x.Id != page.Id).FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null) { ModelState.AddModelError("", "The page already exists."); return View(page); }

                _context.Update(page);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The page has been edited!";
                return RedirectToAction("Edit", new { Id = page.Id});
            }

            return View(page);
        }

        // GET /admin/pages/delete/id
        public async Task<IActionResult> Delete(int id)
        {
            Page page = await _context.Pages.FindAsync(id);
            if (page == null) 
            { 
                TempData["Error"] = "The page does not exists!"; 
            }
            else 
            { 
                _context.Pages.Remove(page); await _context.SaveChangesAsync();

                TempData["Success"] = "The page has been deleted!";
            }

            return RedirectToAction("Index");
        }
    }
}
