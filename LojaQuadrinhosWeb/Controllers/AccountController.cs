using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.BLL.Models;
using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhosWeb.Controllers
{
    //[Authorize(Roles ="Admin")]
    [Authorize]
    public class AccountController : Controller
    {

        IUserService _userService;
        IUserTypeService _userType;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(IUserService userService, IUserTypeService userType, SignInManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _userType = userType;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return RedirectToAction("RegisterExt");
        }


        [AllowAnonymous]
        public async Task<IActionResult> RegisterExtAsync()
        {
            var userTypes = from u in await _userType.GetAllUserTypeAsync() where u.Type != "Employee" select u;
            ViewBag.UserType = new SelectList(userTypes, "Id", "Type");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterExtAsync(ApplicationUser user)
        {
            await _userService.CreateUserAsync(user);
            return RedirectToAction("Index");
        }


        //to internal register, than Employees can be registered
        public async Task<IActionResult> RegisterAsync()
        {
            var userTypes = await _userType.GetAllUserTypeAsync();
            ViewBag.UserType = new SelectList(userTypes, "Id", "Type");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(ApplicationUser user)
        {
            await _userService.CreateUserAsync(user);
            return RedirectToAction("Index");
        }


        //[AllowAnonymous]
        //public IActionResult Login(string returnUrl)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        ViewBag.ReturnUrl = returnUrl;
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        
        
        
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        ////replace with login model later
        //public async Task<ActionResult> Login(LoginModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    else
        //    {

        //        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        return View(model);
        //    }

        //}

        [Authorize]
        public IActionResult Teste()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
               
            return Json("okay");
            }
            else
            {
                return Json("No login");
            }
        }


    }
}
