using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Identity;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{
    public class UserService : IUserService
    {

        IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;

        }

        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<ApplicationUser> GetUserAsync(string id)
        {
            var user = await _repo.Get(id);
            if (user != null) return user;
            else return new ApplicationUser();
        }


        public async Task<IdentityResult> CreateUserAsync(ApplicationUser entity)
        {
            return await _repo.Create(entity);
        }


        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser entity)
        {
            return await _repo.Update(entity);
        }

        public async Task<IdentityResult> DeleteUserAsync(string id)
        {
            var user = _repo.Get(id).Result;
            return await _repo.Delete(user);
        }
    }
}
