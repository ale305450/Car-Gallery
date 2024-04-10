using Learing_Core.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Learing_Core.DTO;
using Learing_Core.Models;

namespace Learing_Core.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CompanyAPIController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete("{id}")] //Delete Company by it id
        public async Task<IActionResult> Delete(int id)
        {
            var company = await _context.company.FindAsync(id);
            if (company == null)
                return BadRequest("Company is not found");
            _context.company.Remove(company);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
