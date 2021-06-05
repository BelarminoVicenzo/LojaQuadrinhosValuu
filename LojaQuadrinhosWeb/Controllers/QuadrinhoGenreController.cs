using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhosWeb.Controllers
{
    public class QuadrinhoGenreController : Controller
    {

        IQuadrinhoGenreService _genreService;
        public QuadrinhoGenreController(IQuadrinhoGenreService stateService)
        {
            _genreService = stateService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            return View(await _genreService.GetAllGenreAsync()) ;
        }

       
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(QuadrinhoGenre state)
        {
            await _genreService.CreateGenreAsync(state);
            return RedirectToAction("Index");
        }

      
        public async Task<IActionResult> UpdateAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var genre = await _genreService.GetGenreAsync((int)id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync([Bind("Id,Name")] QuadrinhoGenre genre)
        {
            if (ModelState.IsValid)
            {
                await _genreService.UpdateGenreAsync(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

   
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var genre = await _genreService.GetGenreAsync((int)id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            await _genreService.DeleteGenreAsync(_genreService.GetGenreAsync(id).Result);
            return RedirectToAction("Index");
        }
    }
}
