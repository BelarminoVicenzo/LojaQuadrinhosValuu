using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public class QuadrinhoStateRepository : IQuadrinhoStateRepository
    {

        private readonly ApplicationDbContext _context;
        
        public QuadrinhoStateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(QuadrinhoState entity)
        {
            _context.QuadrinhoState.Add(entity);
           return await  _context.SaveChangesAsync();
        }

        public async Task<int> Update(QuadrinhoState entity)
        {

            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(QuadrinhoState entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public  async Task<QuadrinhoState> Get(object id)
        {
            return await _context.QuadrinhoState.FindAsync(id);
        }

        public async Task<List<QuadrinhoState>> GetAll()
        {
            return await _context.QuadrinhoState.ToListAsync();
        }

    }
}
