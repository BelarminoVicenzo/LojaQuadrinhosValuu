using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IAspNetRoleService
    {
        Task<IdentityRole> GetRoleAsync(string id);
        Task<IdentityResult> CreateRoleAsync(IdentityRole entity);
        Task<List<IdentityRole>> GetRolesAsync();
        Task<int> UpdateRoleAsync(IdentityRole entity);
        Task<IdentityResult> DeleteRoleAsync(string id);

    }
}
