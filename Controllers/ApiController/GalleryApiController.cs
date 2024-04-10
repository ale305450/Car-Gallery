using Learing_Core.Data;
using Learing_Core.DTO;
using Learing_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Learing_Core.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GalleryApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var gallery = await _context.gallery.FindAsync(id);
            if (gallery == null)
                return NotFound();
            _context.gallery.Remove(gallery);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
