using Learing_Core.Data;
using Learing_Core.Models;
using Learing_Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learing_Core.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GalleryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GalleryController
        public IActionResult Index()
        {
            var gallery = _context.gallery.ToList();
            return View(gallery);
        }

        // GET: GalleryController/Details/5
        public async Task <IActionResult> Details(int id)
        {
            var gallery = await _context.gallery.FindAsync(id);
            if(gallery == null)
                return NotFound();

            return View(gallery);
        }

        // GET: GalleryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GalleryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(GalleryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var gallery = new Gallery()
                {
                    Name = model.Name,
                    Location = model.Location,
                };
                await _context.gallery.AddAsync(gallery);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: GalleryController/Edit/5
        public async Task <IActionResult> Edit(int id)
        {
            var gallery = await _context.gallery.FindAsync(id);
            if (gallery == null)
                return NotFound();
            var viewModel = new GalleryViewModel
            {
                Location = gallery.Location,
                Name = gallery.Name,
            };
            return View(viewModel);
        }

        // POST: GalleryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GalleryViewModel model)
        {
            var gallery = await _context.gallery.FindAsync(id);
            if (gallery == null)
                return NotFound();
            gallery.Name = model.Name;
            gallery.Location = model.Location;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                // If the search term is empty, return all gallery
                return RedirectToAction("Index");
            }

            // Search for gallery by ID or name
            var gallery = _context.gallery.Where(c =>
                c.Id.ToString().Contains(searchTerm) ||
                c.Name.ToLower().Contains(searchTerm)
            );

            return View("Index", gallery);
        }
    }
}
