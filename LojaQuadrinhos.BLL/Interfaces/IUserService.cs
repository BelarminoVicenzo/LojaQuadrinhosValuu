using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserAsync(string id);
        Task<IdentityResult> CreateUserAsync(ApplicationUser entity);
        Task<List<ApplicationUser>> GetUsersAsync();
        Task<IdentityResult> UpdateUserAsync(ApplicationUser entity);
        Task<IdentityResult> DeleteUserAsync(string id);

    }
}
