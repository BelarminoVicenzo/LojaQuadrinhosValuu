using LojaQuadrinhos.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Customer entity)
        {
            _context.Customer.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Customer entity)
        {

            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Customer entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<Customer> Get(object id)
        {
            return await _context.Customer.FindAsync(id);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customer.ToListAsync();
        }

    }
}
