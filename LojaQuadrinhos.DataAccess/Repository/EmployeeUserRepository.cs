using LojaQuadrinhos.DataAccess.DTOs;
using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{

    public class EmployeeUserRepository : IEmployeeUserRepository
    {
        //add AutoMapper later
        private readonly ApplicationDbContext _context;

        UserManager<ApplicationUser> _userManager;

        public EmployeeUserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<int> Create(DTOEmployeeUser employeeUser)
        {
            var employee = new Employee { FullName = employeeUser.FullName, Email = employeeUser.Email };
            var user = new ApplicationUser
            {
                UserName = employeeUser.UserName,
                Email = employeeUser.Email,
                PasswordHash = employeeUser.Password
            };

            _context.Employee.Add(employee);
            await _userManager.CreateAsync(user);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(DTOEmployeeUser employeeUser)
        {
            var employee = _context.Employee.FindAsync(employeeUser.EmployeeId).Result;
            var user = _userManager.FindByIdAsync(employeeUser.UserId).Result;
            _context.Employee.Update(employee);
            await _userManager.UpdateAsync(user);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(DTOEmployeeUser employeeUser)
        {
            var employee = _context.Employee.FindAsync(employeeUser.EmployeeId).Result;
            _context.Employee.Remove(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<DTOEmployeeUser> Get(int id)
        {
            return new DTOEmployeeUser();
        }

        public async Task<List<DTOEmployeeUser>> GetAll()
        {
            return new List<DTOEmployeeUser>();
        }


    }
}
