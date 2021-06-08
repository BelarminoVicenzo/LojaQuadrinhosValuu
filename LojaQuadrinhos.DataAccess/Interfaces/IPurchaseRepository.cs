using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<int> Create(Purchase entity, ApplicationUser user, Quadrinho quadrinho);
        Task<Purchase> Get(object id);
        Task<List<Purchase>> GetAll();

        Task<List<Purchase>> GetFromCustomer(object customerId);
    }
}
