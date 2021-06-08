using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public class UserTypeRepository : IUserTypeRepository
    {

        private readonly ApplicationDbContext _context;
        
        public UserTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(UserType entity)
        {
            _context.UserType.Add(entity);
           return await  _context.SaveChangesAsync();
        }

        public async Task<int> Update(UserType entity)
        {

            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(UserType entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public  async Task<UserType> Get(object id)
        {
            return await _context.UserType.FindAsync(id);
        }

        public async Task<List<UserType>> GetAll()
        {
            return await _context.UserType.ToListAsync();
        }

    }
}
