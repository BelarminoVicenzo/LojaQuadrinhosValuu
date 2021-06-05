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
        public async Task<IActionResult> IndexAsync()
        {

            return View(await _stateService.GetAllStateAsync()) ;
        }

       
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(QuadrinhoState state)
        {
            await _stateService.CreateStateAsync(state);
            return RedirectToAction("Index");
        }

      
        public async Task<IActionResult> UpdateAsync(int? id)
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
        public async Task<IActionResult> UpdateAsync([Bind("Id,Name")] QuadrinhoState state)
        {
            if (ModelState.IsValid)
            {
                await _stateService.UpdateStateAsync(state);
                return RedirectToAction("Index");
            }
            return View(state);
        }

   
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var role = await _stateService.GetStateAsync((int)id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            await _stateService.DeleteStateAsync(_stateService.GetStateAsync(id).Result);
            return RedirectToAction("Index");
        }
    }
}
