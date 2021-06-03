using LojaQuadrinhos.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {

        private readonly ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Purchase entity)
        {
            _context.Purchase.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<Purchase> Get(object id)
        {
            return await _context.Purchase.FindAsync(id);
        }

        public async Task<List<Purchase>> GetAll()
        {
            return await _context.Purchase.ToListAsync();
        }
        
        public async Task<List<Purchase>> GetFromCustomer(object customerId)
        {
            return await _context.Purchase.Where(p => p.Id == (int)customerId).ToListAsync();
        }
        
    }
}
