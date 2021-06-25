using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> Create(ApplicationUser entity);
        Task<IdentityResult> Delete(ApplicationUser entity);
        Task<IdentityResult> Update(ApplicationUser entity);
        Task<List<ApplicationUser>> GetAll();
        Task<ApplicationUser> Get(string id);
        Task<IdentityResult> AddToRole(ApplicationUser user, string roleName);
        Task<IdentityResult> RemoveFromRole(ApplicationUser user, string roleName);
        Task<List<string>> GetRolesFromUser(ApplicationUser user);
        Task<ApplicationUser> GetUserByUserNameAsync(string userName);
        string GetUserId(string userName);
    }
}
