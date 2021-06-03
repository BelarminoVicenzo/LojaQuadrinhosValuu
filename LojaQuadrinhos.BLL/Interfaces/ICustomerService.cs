using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface ICustomerService<T>
    {
        Task<T> GetCustomerAsync(int id);
        Task<int> CreateCustomerAsync(T entity);
        Task<List<T>> GetAllCustomersAsync();
        Task<int> UpdateCustomerAsync(T entity);
        Task<int> DeleteCustomerAsync(T entity);
    }
}
