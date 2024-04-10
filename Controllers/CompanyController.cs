using Learing_Core.Data;
using Learing_Core.Models;
using Learing_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Learing_Core.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task< IActionResult> Index()
        {
            //Get all Companies in Db
            var company = _context.company.ToList();
            return View(company);
        }

        public async Task<IActionResult> Details(int id)
        {
            //Get Company info by id
            var company = await _context.company.FindAsync(id);
            if(company == null)
                return NotFound();
            return View(company);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            //Add New Company
            var company = new Company()
            {
                Name = model.Name,
                Description = model.Description,
                CompanyLogo = uploadImage(model.CompanyLogo),
            };

            await _context.company.AddAsync(company);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Get company by id to fill the form with it infromation
            var company= await _context.company.FindAsync(id);
            var viewModel = new CompanyViewModel
            {
                Name = company.Name,
                Description = company.Description,
                CompanyLogo = company.CompanyLogo,
            };
            return View(viewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyViewModel model)
        {
            //Check if company existis 
            var company = await _context.company.FindAsync(id);
            if (company == null)
                return NotFound();
            //Update Company information
            company.Name = model.Name;
            company.Description = model.Description;
            if(uploadImage(model.CompanyLogo) != null)
                company.CompanyLogo = uploadImage(model.CompanyLogo);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                // If the search term is empty, return all Companies
                return RedirectToAction("Index");
            }
            // Search for Company by ID or name
            var company = _context.company.Where(c =>
                c.Id.ToString().Contains(searchTerm) ||
                c.Name.ToLower().Contains(searchTerm)
            );

            return View("Index", company);
        }
        public byte[] uploadImage(byte[] image)
        {
            // Check how many files are being send
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.FirstOrDefault();//Get the first file
                using (var memory = new MemoryStream())
                {
                    file.CopyToAsync(memory);
                    image = memory.ToArray();
                }
            }
            return image;
        }

    }
}
