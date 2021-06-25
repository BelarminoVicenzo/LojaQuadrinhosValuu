using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{

    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;

        UserManager<ApplicationUser> _userManager;
        private IPasswordHasher<ApplicationUser> _passwordHasher;

        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _context = context;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }
        public async Task<IdentityResult> Create(ApplicationUser entity)
        {
            entity.PasswordHash = _passwordHasher.HashPassword(entity, entity.PasswordHash);
            entity.UserName = entity.Email;
            return await _userManager.CreateAsync(entity);
        }

        public async Task<IdentityResult> Update(ApplicationUser entity)
        {
            return await _userManager.UpdateAsync(entity);
        }

        public async Task<IdentityResult> Delete(ApplicationUser entity)
        {
            return await _userManager.DeleteAsync(entity);
        }

        public async Task<ApplicationUser> Get(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _userManager.Users.ToListAsync();
        }


        public async Task<IdentityResult> AddToRole(ApplicationUser user, string roleName)
        {
            return await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> RemoveFromRole(ApplicationUser user, string roleName)
        {
            return await _userManager.RemoveFromRoleAsync(user, roleName);
        }

        public async Task<List<string>> GetRolesFromUser(ApplicationUser user)
        {
            return (List<string>)await _userManager.GetRolesAsync(user);
        }

        public Task<ApplicationUser> GetUserByUserNameAsync(string userName)
        {
            return _userManager.FindByNameAsync(userName);

        }

        public string GetUserId(string userName)
        {
                return _context.Users.Where(u => u.UserName == userName).Select(u=>u.Id).FirstOrDefault();
        }
    }
}
