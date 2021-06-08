using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public class QuadrinhoGenreRepository : IQuadrinhoGenreRepository
    {

        private readonly ApplicationDbContext _context;
        
        public QuadrinhoGenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(QuadrinhoGenre entity)
        {
            _context.QuadrinhoGenre.Add(entity);
           return await  _context.SaveChangesAsync();
        }

        public async Task<int> Update(QuadrinhoGenre entity)
        {

            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(QuadrinhoGenre entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public  async Task<QuadrinhoGenre> Get(object id)
        {
            return await _context.QuadrinhoGenre.FindAsync(id);
        }

        public async Task<List<QuadrinhoGenre>> GetAll()
        {
            return await _context.QuadrinhoGenre.ToListAsync();
        }

    }
}
