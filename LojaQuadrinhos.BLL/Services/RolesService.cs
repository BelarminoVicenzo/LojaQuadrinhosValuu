using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{
    public class RolesService : IRolesService
    {

        IRolesRepository _repo;
        public RolesService(IRolesRepository repo)
        {
            _repo = repo;

        }

        public async Task<List<IdentityRole>> GetRolesAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<IdentityRole> GetRoleAsync(string id)
        {
            var role = await _repo.Get(id);
            if (role != null) return role;
            else return new IdentityRole();
        }


        public async Task<IdentityResult> CreateRoleAsync(IdentityRole entity)
        {
            return await _repo.Create(entity);
        }

        
        public async Task<IdentityResult> UpdateRoleAsync(IdentityRole entity)
        {
            return await _repo.Update(entity);
        }

        public async Task<IdentityResult> DeleteRoleAsync(string id)
        {
            var role=_repo.Get(id).Result;
            return await _repo.Delete(role);
        }

        public string GetRoleName(string id)
        {
            return GetRoleAsync(id).Result.Name;
        }
    }
}
