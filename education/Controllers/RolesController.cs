using education.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreApp.Controllers
{
    [Authorize(Roles = clsRoles.roleAdmin)]
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> _user;
        private readonly RoleManager<IdentityRole> _roles;

        public RolesController(UserManager<IdentityUser> user, RoleManager<IdentityRole> roles)
        {
            _user = user;
            _roles = roles;
        }

        public async Task<IActionResult> Index()
        {
            var _users = await _user.Users.ToListAsync();
            return View(_users);
        }

        public async Task<IActionResult> addRoles(string userId)
        {
            var user = await _user.FindByIdAsync(userId);
            var userRoles = await _user.GetRolesAsync(user);

            var allRoles = await _roles.Roles.ToListAsync();
            if (allRoles != null)
            {
                var roleList = allRoles.Select(r => new roleViewModel()
                {
                    roleId = r.Id,
                    roleName = r.Name,
                    useRole = userRoles.Any(x => x == r.Name)
                });
                ViewBag.userName = user.UserName;
                ViewBag.userId = userId;
                return View(roleList);
            }
            else
                return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addRoles(string userId, string jsonRoles)
        {
            var user = await _user.FindByIdAsync(userId);

            List<roleViewModel> myRoles =
                JsonConvert.DeserializeObject<List<roleViewModel>>(jsonRoles);

            if (user != null)
            {
                var userRoles = await _user.GetRolesAsync(user);

                foreach (var role in myRoles)
                {
                    if (userRoles.Any(x => x == role.roleName.Trim()) && !role.useRole)
                    {
                        await _user.RemoveFromRoleAsync(user, role.roleName.Trim());
                    }

                    if (!userRoles.Any(x => x == role.roleName.Trim()) && role.useRole)
                    {
                        await _user.AddToRoleAsync(user, role.roleName.Trim());
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            var user = await _user.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _user.DeleteAsync(user);
            if (!result.Succeeded)
            {
                
                return View("Error");
            }

            return RedirectToAction(nameof(Index)); 
        }
    }
}
