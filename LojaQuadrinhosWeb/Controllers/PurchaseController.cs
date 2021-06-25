using LojaQuadrinhos.BLL.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhosWeb.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        IPurchaseService _purchase; 
        IQuadrinhoService _quadrinhoService;

        public PurchaseController(IPurchaseService purchase, IQuadrinhoService quadrinhoService)
        {
            _purchase=purchase;
            _quadrinhoService = quadrinhoService;
        }
        
        [Authorize(Roles ="Admin,Internal")]
        public async Task<IActionResult> Index()
        {
                var a= await _purchase.GetAllPurchasesAsync();
            return View(a);
        }
         
        public async Task<IActionResult> MyHistory([FromServices] IUserService userService)
        {
            var userId =  userService.GetUserId(User.Identity.Name);
            var purchase = await _purchase.GetAllFromCustomer(userId);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }
        
        
    }
}
