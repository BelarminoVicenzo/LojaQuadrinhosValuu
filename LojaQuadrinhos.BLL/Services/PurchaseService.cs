using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.DataAccess.Repository;
using LojaQuadrinhos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{
    public class PurchaseService : IPurchaseService
    {

        IPurchaseRepository _repo;
        ICustomerRepository _custRepo;
        IQuadrinhoService _quadService;
        public PurchaseService(IPurchaseRepository repo, ICustomerRepository custRepo, IQuadrinhoService quadService)
        {
            _repo = repo;
            _custRepo = custRepo;
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


        public async Task<int> CreatePurchaseAsync(Purchase entity, Customer customer, Quadrinho quadrinho)
        {

            var quad = _quadService.GetQuadrinhoAsync(quadrinho.Id).Result;
            if (CheckQuadrinhoAvaiability(entity.PurchasedQuantity,quad.Quantity))
            {

            quad.Quantity -= entity.PurchasedQuantity;
            return await _repo.Create(entity, customer, quad);
            }
            else
            {
                return 0;
            }
        }


        public async Task<List<Purchase>> GetAllFromCustomer(object customerId)
        {
            return await _repo.GetFromCustomer(customerId);
        }


        public bool CheckQuadrinhoAvaiability(int purchaseQuantity,int quadrinhoQuantity)
        {
            return quadrinhoQuantity>=purchaseQuantity ? true: false;
        }

    }
}
