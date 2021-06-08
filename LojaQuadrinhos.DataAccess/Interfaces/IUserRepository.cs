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
        
    }
}
