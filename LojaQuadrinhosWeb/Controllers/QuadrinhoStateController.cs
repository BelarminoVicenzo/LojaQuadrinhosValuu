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
    public class QuadrinhoStateController : Controller
    {

        IQuadrinhoStateService _stateService;
        public QuadrinhoStateController(IQuadrinhoStateService stateService)
        {
            _stateService = stateService;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _stateService.GetAllStateAsync()) ;
        }

       
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuadrinhoState state)
        {
            await _stateService.CreateStateAsync(state);
            return RedirectToAction("Index");
        }

      
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var state = await _stateService.GetStateAsync((int)id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("Id,Name")] QuadrinhoState state)
        {
            if (ModelState.IsValid)
            {
                await _stateService.UpdateStateAsync(state);
                return RedirectToAction("Index");
            }
            return View(state);
        }

   
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var state = await _stateService.GetStateAsync((int)id);
            if (state == null)
            {
                return NotFound();
            }
            return View(state);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _stateService.DeleteStateAsync(_stateService.GetStateAsync(id).Result);
            return RedirectToAction("Index");
        }
    }
}
