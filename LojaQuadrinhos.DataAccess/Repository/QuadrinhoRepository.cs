using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public class QuadrinhoRepository : IQuadrinhoRepository
    {

        private readonly ApplicationDbContext _context;

        public QuadrinhoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Quadrinho entity)
        {
            _context.Quadrinho.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Quadrinho entity)
        {

            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Quadrinho entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<Quadrinho> Get(object id)
        {
            return await _context.Quadrinho.FindAsync(id);
        }

        public async Task<List<Quadrinho>> GetAll()
        {
            return await _context.Quadrinho.ToListAsync();
        }

    }
}
