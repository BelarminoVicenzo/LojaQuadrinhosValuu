using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.DataAccess.Repository;
using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{
    public class CustomerService : ICustomerService<Customer>
    {

        ICustomerRepository _repo;
        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var costumer = await _repo.Get(id);
            if (costumer != null) return costumer;
            else return new Customer();
        }


        public async Task<int> CreateCustomerAsync(Customer entity)
        {
                return await _repo.Create(entity);
        }

        public async Task<int> UpdateCustomerAsync(Customer entity)
        {
            return await _repo.Update(entity);
        }

        public async Task<int> DeleteCustomerAsync(Customer entity)
        {
            return await _repo.Delete(entity);
        }

    }
}
