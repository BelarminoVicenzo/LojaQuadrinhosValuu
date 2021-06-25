using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.BLL.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LojaQuadrinhosWeb.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        IRolesService _roleService;
        IUserService _userService;

        public RolesController(IRolesService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _roleService.GetRolesAsync()); ;

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await _roleService.CreateRoleAsync(role);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(string id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var role = await _roleService.GetRoleAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("Id,Name")] IdentityRole role)
        {

            if (ModelState.IsValid)
            {
                await _roleService.UpdateRoleAsync(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public async Task<IActionResult> Delete(string id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var role = await _roleService.GetRoleAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _roleService.DeleteRoleAsync(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> AddUserToRole()
        {
            await PopulateRoleAndUserDropDown();

            return View();
        }




        private async Task PopulateRoleAndUserDropDown()
        {
            var roles = await _roleService.GetRolesAsync();
            var users = _userService.GetUsersWithoutSensitiveInfo();


            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            ViewBag.Users = new SelectList(users, "Id", "UserName");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserToRole(UserRoleModel model)
        {

            var roleName = _roleService.GetRoleName(model.RoleId);

            var result = await _userService.AddToRole(model.UserId, roleName);
            if (result.Succeeded == false)
            {
                //lets say there's only one error
                ViewBag.Message = result.Errors.FirstOrDefault().Description;
            }

            await PopulateRoleAndUserDropDown();
            return View();
        }
        public async Task<IActionResult> RemoveUserFromRole()
        {
            var user = await _userService.GetUserWithoutSensitiveInfoAsync(User.Identity.Name);
            
             await PopulateRoleAndUserDropDown();
            return View(new UserRoleModel { UserId = user.Id, UserName = user.UserName });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveUserFromRole(UserRoleModel model)
        {

            var roleName = model.RoleName;

            var result = await _userService.RemoveFromRole(model.UserId, roleName);
            if (result.Succeeded == false)
            {
                //lets say there's only one error
                ViewBag.Message = result.Errors.FirstOrDefault().Description;
            }

            await PopulateRoleAndUserDropDown();
            return View();
        }

        [HttpGet]
        public async Task<List<string>> GetRolesFromUser(string username)
        {
            var user = await _userService.GetUserWithoutSensitiveInfoAsync(username);
            var roles = await _userService.GetRolesFromUser(user.Id);
            return roles;
        }
        
       

    }


}
