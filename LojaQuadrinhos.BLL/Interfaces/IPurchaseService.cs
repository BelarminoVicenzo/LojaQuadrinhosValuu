using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IPurchaseService<T>
    {
        Task<int> CreatePurchaseAsync(T entity);
        Task<T> GetPurchaseAsync(int id);
        Task<List<T>> GetAllFromCustomer(object customerId);
        Task<List<T>> GetAllPurchasesAsync();
    }
}
