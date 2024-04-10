using Learing_Core.Models;
using Learing_Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learing_Core.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly RoleManager<IdentityRole> _roleManger;
        public UsersController(UserManager<ApplicationUser> userManger, RoleManager<IdentityRole> roleManger)
        {
            this._userManger = userManger;
            this._roleManger = roleManger;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManger.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Roles = _userManger.GetRolesAsync(user).Result
            }).ToListAsync();

            return View(users);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if (await _userManger.FindByEmailAsync(model.Email) != null)
            {
                ModelState.AddModelError("Email", "This email is already exists");
                return View(model);
            }
            if(await _userManger.FindByNameAsync(model.UserName) != null)
            {
                ModelState.AddModelError("UserName", "This user name is already exists");
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
            };
            var result  = await _userManger.CreateAsync(user,model.Password);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
            await _userManger.AddToRoleAsync(user, "User");
            return View(model);
        }

        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userManger.FindByIdAsync(userId);
            if(user == null)
                return NotFound();

            var viewModel = new EditUserViewModel
            {
                Id = userId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await _userManger.FindByIdAsync(model.Id);
            if (user == null)
                return NotFound();

            var userWithSameName = await _userManger.FindByNameAsync(model.UserName);
            if (userWithSameName != null && userWithSameName.Id != model.Id)
            {
                ModelState.AddModelError("UserName", "There is user with the same userName exists");
                return View(model);
            }

            var userWithSameEmail = await _userManger.FindByEmailAsync(model.Email);
            if(userWithSameEmail != null && userWithSameEmail.Id != model.Id)
            {
                ModelState.AddModelError("Email", "There is user with the same Email exists");
                return View(model);
            }
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.UserName;
            await _userManger.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

    }
}
