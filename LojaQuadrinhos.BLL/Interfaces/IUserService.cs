using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserAsync(string id);
        List<ApplicationUser> GetUserWithoutSensetiveInfo();
        Task<IdentityResult> CreateUserAsync(ApplicationUser entity);
        Task<List<ApplicationUser>> GetUsersAsync();
        Task<IdentityResult> UpdateUserAsync(ApplicationUser entity);
        Task<IdentityResult> DeleteUserAsync(string id);
        Task<IdentityResult> AddToRole(string userId, string roleName);
        Task<IdentityResult> RemoveFromRole(string userId, string roleName);
        Task<List<string>> GetRolesFromUser(string userId);
        Task<ApplicationUser> GetUserByUserNameAsync(string userName);

    }
}
