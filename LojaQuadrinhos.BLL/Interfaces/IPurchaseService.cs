using LojaQuadrinhos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IPurchaseService
    {
        Task<int> CreatePurchaseAsync(Purchase entity, Customer customer, Quadrinho quadrinho);
        Task<Purchase> GetPurchaseAsync(int id);
        Task<List<Purchase>> GetAllFromCustomer(object customerId);
        Task<List<Purchase>> GetAllPurchasesAsync();
        bool CheckQuadrinhoAvaiability(int purchaseQuantity,int quadrinhoQuantity);
    }
}
