using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhosWeb.Controllers
{
    public class UsersController : Controller
    {

        IUserService _userService;
        IUserTypeService _userType;
        public UsersController(IUserService userService, IUserTypeService userType)
        {
            _userService = userService;
            _userType = userType;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetUsersAsync()) ;
        }

       
        public async Task<IActionResult> Create()
        {
            var userTypes = from u in await _userType.GetAllUserTypeAsync() where u.Type!="Employee" select u;
            ViewBag.UserType = new SelectList(userTypes, "Id", "Type") ;
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
            await _userService.CreateUserAsync(user);
            return RedirectToAction("Index");
        }

      
        public async Task<IActionResult> Update(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var state = await _userService.GetUserAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("Id,Name")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateUserAsync(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

   
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var state = await _userService.GetUserAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            return View(state);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
    }
}
