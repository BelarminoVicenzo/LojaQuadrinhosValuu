using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{
    public class AspNetRoleService : IAspNetRoleService
    {

        IAspNetRoleRepository _repo;
        public AspNetRoleService(IAspNetRoleRepository repo)
        {
            _repo = repo;

        }

        public async Task<List<IdentityRole>> GetRolesAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<IdentityRole> GetRoleAsync(string id)
        {
            var purch = await _repo.Get(id);
            if (purch != null) return purch;
            else return new IdentityRole();
        }


        public async Task<IdentityResult> CreateRoleAsync(IdentityRole entity)
        {
            return await _repo.Create(entity);
        }

        
        public async Task<int> UpdateRoleAsync(IdentityRole entity)
        {
            return await _repo.Update(entity);
        }

        public async Task<IdentityResult> DeleteRoleAsync(string id)
        {
            var role=_repo.Get(id).Result;
            return await _repo.Delete(role);
        }
    }
}
