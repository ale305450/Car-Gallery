using Learing_Core.Data;
using Learing_Core.Models;
using Learing_Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Learing_Core.Controllers
{

    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //To get All cars so it for sell or for rent
            var car = _context.car.Include(c => c.Company).Include(r => r.RentalCar).ToList();
            return View(car);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //Get all company and rent and gallery to fill it in Combobox
            var company = _context.company.ToList();
            var rentalCar = _context.rentalCar.ToList();
            var gallery = _context.gallery.ToList();
            var viewModel = new CarViewModel
            {
                RentalCar = rentalCar,
                Company = company,
                Galleries = gallery,
                RentalCarId = null
            };
            return View(viewModel);
        }

        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Add new car
                var car = new Car
                {
                    Name = model.Name,
                    Description = model.Description,
                    Car_Model = model.Car_Model,
                    CompanyId = model.CompanyId,
                    ContactNumbr = model.ContactNumbr,
                    Price = model.Price,
                    RentalCarId = model.RentalCarId,
                    CarImage1 = uploadImage(model.CarImage1, 0),
                    CarImage2 = uploadImage(model.CarImage2, 1),
                    CarImage3 = uploadImage(model.CarImage3, 2),
                    GalleryId = model.GalleryId,
                };
                await _context.car.AddAsync(car);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _context.car.FindAsync(id);
            if (car == null)
                return NotFound();
            //Fill Combobox
            var company = _context.company.ToList();
            var rentalCar = _context.rentalCar.ToList();
            var gallery = _context.gallery.ToList();

            var viewModel = new CarViewModel
            {
                Name = car.Name,
                Description = car.Description,
                Car_Model = car.Car_Model,
                CompanyId = car.CompanyId,
                ContactNumbr = car.ContactNumbr,
                Price = car.Price,
                RentalCarId = car.RentalCarId,
                CarImage1 = car.CarImage1,
                CarImage2 = car.CarImage2,
                CarImage3 = car.CarImage3,
                GalleryId = car.GalleryId,
                RentalCar = rentalCar,
                Company = company,
                Galleries = gallery,
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarViewModel model)
        {
            var car = await _context.car.FindAsync(id);
            if (car == null)
                return NotFound();
            //Fill car changed information
            car.Name = model.Name;
            car.Description = model.Description;
            car.Car_Model = model.Car_Model;
            car.CompanyId = model.CompanyId;
            car.ContactNumbr = model.ContactNumbr;
            car.Price = model.Price;
            car.RentalCarId = model.RentalCarId;
            car.GalleryId = model.GalleryId;
            // Check if there change in the image 
            if(uploadImage(model.CarImage1, 0) != null)
                car.CarImage1 = uploadImage(model.CarImage1, 0);
            if(uploadImage(model.CarImage2, 1) != null)
                car.CarImage2 = uploadImage(model.CarImage2, 1);
            if(uploadImage(model.CarImage3, 2) != null)
                car.CarImage3 = uploadImage(model.CarImage3, 2);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            //Find car by id and get it detalis
            var car = await _context.car.FindAsync(id);
            if (car == null)
                return NotFound();

            return View(car);
        }

        public ActionResult Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                // If the search term is empty, return all Cars
                return RedirectToAction("Index");
            }

            // Search for Car by ID or name
            var car = _context.car.Where(c =>
                c.Id.ToString().Contains(searchTerm) ||
                c.Name.ToLower().Contains(searchTerm)
            );

            return View("Index", car);
        }
        //Add image file
        public byte[] uploadImage(byte[] image,int index)
        {
            // Check how many files are being send
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.ToList();//Get the first file
                using (var memory = new MemoryStream())
                {
                    file[index].CopyToAsync(memory);
                    image = memory.ToArray();
                }
            }
            return image;
        }

    }
}
