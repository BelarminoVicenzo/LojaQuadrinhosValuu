using LojaQuadrinhos.BLL.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LojaQuadrinhosWeb.Controllers
{
    public class RolesController : Controller
    {
        IAspNetRoleService _roleService;

        public RolesController(IAspNetRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _roleService.GetRolesAsync()); ;

        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
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
            var role= await _roleService.GetRoleAsync(id);
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


    }


}
