using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{
    public class PurchaseService : IPurchaseService
    {

        IPurchaseRepository _repo;
        IAspNetUserRepository _userRepo;
        IQuadrinhoService _quadService;
        public PurchaseService(IPurchaseRepository repo, IAspNetUserRepository custRepo, IQuadrinhoService quadService)
        {
            _repo = repo;
            _userRepo = custRepo;
            _quadService = quadService;
        }

        public async Task<List<Purchase>> GetAllPurchasesAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<Purchase> GetPurchaseAsync(int id)
        {
            var purch = await _repo.Get(id);
            if (purch != null) return purch;
            else return new Purchase();
        }


        public async Task<int> CreatePurchaseAsync(Purchase entity, ApplicationUser user, Quadrinho quadrinho)
        {

            var quad = _quadService.GetQuadrinhoAsync(quadrinho.Id).Result;
            if (CheckQuadrinhoAvaiability(entity.PurchasedQuantity, quad.Quantity))
            {

                quad.Quantity -= entity.PurchasedQuantity;
                return await _repo.Create(entity, user, quad);
            }
            else
            {
                return 0;
            }
            return 0;
        }


        public async Task<List<Purchase>> GetAllFromCustomer(object customerId)
        {
            return await _repo.GetFromCustomer(customerId);
        }


        public bool CheckQuadrinhoAvaiability(int purchaseQuantity, int quadrinhoQuantity)
        {
            return quadrinhoQuantity >= purchaseQuantity ? true : false;
        }

    }
}
