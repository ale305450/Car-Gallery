using Learing_Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learing_Core.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var role = await _roleManager.Roles.ToListAsync();
            return View(role);
        }
    }
}
