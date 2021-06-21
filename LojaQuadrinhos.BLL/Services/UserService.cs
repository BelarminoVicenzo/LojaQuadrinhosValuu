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
        UserManager<ApplicationUser> _userManager;
        IUserTypeService _userTypeService;
        public UserService(IUserRepository repo, UserManager<ApplicationUser> userManager, IUserTypeService userTypeService)
        {
            _repo = repo;
            _userManager = userManager;
            _userTypeService = userTypeService;
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



        public List<ApplicationUser> GetUserWithoutSensetiveInfo()
        {
            var users = _repo.GetAll().Result;

            var userInsensitive = new List<ApplicationUser>();
            foreach (var user in users)
            {
                user.PasswordHash = string.Empty;
                userInsensitive.Add(user);
            }
            return userInsensitive;

        }


        public async Task<IdentityResult> CreateUserAsync(ApplicationUser entity)
        {

            var result = await _repo.Create(entity);
            var ut = await _userTypeService.GetUserTypeAsync(entity.UserTypeId);
            if (result.Succeeded && ut.Type != "Employee")
            {
                return await _userManager.AddToRoleAsync(entity, "External");
            }
            return result;

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

        public async Task<IdentityResult> AddToRole(string userId, string roleName)
        {
            var user = await GetUserAsync(userId);
            return await _repo.AddToRole(user, roleName);
        }

        public async Task<IdentityResult> RemoveFromRole(string userId, string roleName)
        {
            var user = await GetUserAsync(userId);
            return await _repo.RemoveFromRole(user, roleName);
        }

        public async Task<List<string>> GetRolesFromUser(string userId)
        {
            var user = await GetUserAsync(userId);
            return await _repo.GetRolesFromUser(user);
        }

        public Task<ApplicationUser> GetUserByUserNameAsync(string userName)
        {
            return _repo.GetUserByUserNameAsync(userName);
        }
    }
}
