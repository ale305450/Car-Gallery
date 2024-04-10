using Learing_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Learing_Core.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManger;
        public UsersApiController(UserManager<ApplicationUser> userManger)
        {
            _userManger = userManger;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string userId)
        {
            var user = await _userManger.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            var result = await _userManger.DeleteAsync(user);
            if (!result.Succeeded)
                throw new Exception();

            return Ok();
        }
    }
}
