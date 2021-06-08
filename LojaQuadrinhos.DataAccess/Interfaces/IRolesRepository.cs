using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Interfaces
{
    public interface IRolesRepository
    {
        Task<IdentityResult> Create(IdentityRole entity);
        Task<IdentityResult> Delete(IdentityRole entity);
        Task<IdentityResult> Update(IdentityRole entity);
        Task<List<IdentityRole>> GetAll();
        Task<IdentityRole> Get(string id);
        
    }
}
