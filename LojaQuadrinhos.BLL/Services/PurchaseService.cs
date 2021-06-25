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
        IUserRepository _userRepo;
        IQuadrinhoService _quadService;
        public PurchaseService(IPurchaseRepository repo, IUserRepository custRepo, IQuadrinhoService quadService)
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


        public async Task<int> CreatePurchaseAsync(Purchase entity, ApplicationUser user)
        {

            var quadrinho = _quadService.GetQuadrinhoAsync(entity.QuadrinhoId).Result;
            if (CheckQuadrinhoAvaiability(entity.PurchasedQuantity, quadrinho.Quantity))
            {
                ConfigurePurchase(entity, user, quadrinho);
                return await _repo.Create(entity, user);
            }
            else
            {
                return 0;
            }
        }

        private void ConfigurePurchase(Purchase entity, ApplicationUser user, Quadrinho quadrinho)
        {
            entity.UserId = user.Id;
            entity.QuadrinhoId = quadrinho.Id;
            entity.Quadrinho = quadrinho;
            entity.User = user;
            entity.Id = 0;//somehow it was getting the Quadrinho.Id one
            quadrinho.Quantity -= entity.PurchasedQuantity;
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
