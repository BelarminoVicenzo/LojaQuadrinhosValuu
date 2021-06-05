using LojaQuadrinhos.DataAccess.Interfaces;

using Microsoft.AspNetCore.Identity;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public interface IAspNetRoleRepository
    {
        Task<IdentityResult> Create(IdentityRole entity);
        Task<IdentityResult> Delete(IdentityRole entity);
        Task<int> Update(IdentityRole entity);
        Task<List<IdentityRole>> GetAll();
        Task<IdentityRole> Get(string id);
        
    }
}
