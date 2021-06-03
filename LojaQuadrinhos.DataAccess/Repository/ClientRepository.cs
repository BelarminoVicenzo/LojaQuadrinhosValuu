using LojaQuadrinhos.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public class ClientRepository : IClientRepository
    {

        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Client entity)
        {
            _context.Client.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Client entity)
        {

            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Client entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<Client> Get(object id)
        {
            return await _context.Client.FindAsync(id);
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.Client.ToListAsync();
        }

    }
}
