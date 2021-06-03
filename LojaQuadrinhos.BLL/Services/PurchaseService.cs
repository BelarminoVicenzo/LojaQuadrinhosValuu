using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.DataAccess.Repository;
using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{
    public class PurchaseService : IPurchaseService<Purchase>
    {

        IPurchaseRepository _repo;
        public PurchaseService(IPurchaseRepository repo)
        {
            _repo = repo;
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


        public async Task<int> CreatePurchaseAsync(Purchase entity)
        {
                return await _repo.Create(entity);
        }


        public async Task<List<Purchase>> GetAllFromCustomer(object customerId)
        {
            return await _repo.GetFromCustomer(customerId);
        }

        
    }
}
