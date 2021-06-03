using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Employee entity)
        {
            _context.Employee.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Employee entity)
        {

            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Employee entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<Employee> Get(object id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employee.ToListAsync();
        }

    }
}
