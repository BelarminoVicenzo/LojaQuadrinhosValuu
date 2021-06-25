using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhosWeb.Controllers
{
    [Authorize]
    public class QuadrinhoController : Controller
    {

        IQuadrinhoService _quadrinhoService;
        IQuadrinhoStateService _stateService;
        IQuadrinhoGenreService _genreService;
       
        public QuadrinhoController(IQuadrinhoService quadrinhoService, IQuadrinhoStateService stateService,
            IQuadrinhoGenreService genreService)
        {
            _quadrinhoService = quadrinhoService;
            _stateService = stateService;
            _genreService = genreService;
            
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {

            return View(await _quadrinhoService.GetAllQuadrinhosAsync());
        }

        public async Task<IActionResult> CreateAsync()
        {
            await FillStateAndGenreDropDown();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Quadrinho quadrinho)
        {
            await _quadrinhoService.CreateQuadrinhoAsync(quadrinho);
            return RedirectToAction("Index");
        }


        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var quadrinho = await _quadrinhoService.GetQuadrinhoAsync((int)id);
            if (quadrinho == null)
            {
                return NotFound();
            }

            return View(quadrinho);
        }

        
        public async Task<IActionResult> Update(int? id)
        {
            await FillStateAndGenreDropDown();

            if (id == null)
            {
                return BadRequest();
            }
            var quadrinho = await _quadrinhoService.GetQuadrinhoAsync((int)id);
            if (quadrinho == null)
            {
                return NotFound();
            }

            return View(quadrinho);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("Id,Name,QuadrinhoStateId,GenreId,ChapterNumbers,Quantity")] Quadrinho quadrinho)
        {
            if (ModelState.IsValid)
            {
                await _quadrinhoService.UpdateQuadrinhoAsync(quadrinho);
                return RedirectToAction("Index");
            }
            return View(quadrinho);
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var quadrinho = await _quadrinhoService.GetQuadrinhoAsync((int)id);
            if (quadrinho == null)
            {
                return NotFound();
            }
            return View(quadrinho);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _quadrinhoService.DeleteQuadrinhoAsync(_quadrinhoService.GetQuadrinhoAsync(id).Result);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> AddToCart(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var quadrinho = await _quadrinhoService.GetQuadrinhoAsync((int)id);
            return View(quadrinho);
        }



        [Authorize]
        public async Task<IActionResult> Buy(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var quadrinho = await _quadrinhoService.GetQuadrinhoAsync((int)id);
            
            //no need to handle the error bc it won't trigger here first
            //it will trigger in QuadrinhoRepository
            
            var purchase = new Purchase
            {
                QuadrinhoId = quadrinho.Id,
                Quadrinho=quadrinho,
            };
            return View(purchase);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(Purchase purchase, [FromServices] IPurchaseService purchaseService, [FromServices] IUserService userService)
        {
            purchase.PurchaseDate = DateTime.Now;
            var user = await userService.GetUserWithoutSensitiveInfoAsync(User.Identity.Name);
            await purchaseService.CreatePurchaseAsync(purchase,user);
            return RedirectToAction("Index");
        }


        private async Task FillStateAndGenreDropDown()
        {
            var states = await _stateService.GetAllStateAsync();
            var genres = await _genreService.GetAllGenreAsync();

            ViewBag.States = new SelectList(states, "Id", "Name");
            ViewBag.Genres = new SelectList(genres, "Id", "Name");
        }
    }
}
