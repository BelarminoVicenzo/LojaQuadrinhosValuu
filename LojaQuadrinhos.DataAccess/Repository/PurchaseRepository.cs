using LojaQuadrinhos.DataAccess.Interfaces;
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
        public async Task<int> Create(Purchase entity, ApplicationUser user)
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
            return await _context.Purchase.Include(q => q.Quadrinho).Include(u => u.User).ToListAsync();
        }

        public async Task<List<Purchase>> GetFromCustomer(object customerId)
        {
            return await _context.Purchase.Include(q => q.Quadrinho)
                .Where(p => p.UserId == customerId.ToString())
                .ToListAsync();
        }

    }
}
