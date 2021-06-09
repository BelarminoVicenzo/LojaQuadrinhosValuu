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
    public class QuadrinhoController : Controller
    {

        IQuadrinhoService _quadrinhoService;
        IQuadrinhoStateService _stateService;
        IQuadrinhoGenreService _genreService;
        public QuadrinhoController(IQuadrinhoService quadrinhoService, IQuadrinhoStateService stateService, IQuadrinhoGenreService genreService)
        {
            _quadrinhoService = quadrinhoService;
            _stateService = stateService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _quadrinhoService.GetAllQuadrinhosAsync()) ;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart()
        {

            return View();
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
