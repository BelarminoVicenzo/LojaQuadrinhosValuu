using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public interface IPurchaseRepository:IGenericRepository<Purchase>
    {
        Task<List<Purchase>> GetFromCustomer(object customerId);
    }
}
