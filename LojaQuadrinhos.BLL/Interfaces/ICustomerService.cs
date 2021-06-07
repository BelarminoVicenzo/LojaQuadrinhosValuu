using LojaQuadrinhos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerAsync(int id);
        Task<int> CreateCustomerAsync(Customer entity);
        Task<List<Customer>> GetAllCustomersAsync();
        Task<int> UpdateCustomerAsync(Customer entity);
        Task<int> DeleteCustomerAsync(Customer entity);
    }
}
