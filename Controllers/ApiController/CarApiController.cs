using Learing_Core.Data;
using Learing_Core.DTO;
using Learing_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learing_Core.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CarApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Get Car by it id to delete it
            var car = await _context.car.FindAsync(id);
            if (car == null)
                return NotFound();
            _context.Remove(car);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
