using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{

    public class AspNetRoleRepository : IAspNetRoleRepository
    {

        private readonly ApplicationDbContext _context;

        RoleManager<IdentityRole> _roleManager;

        public AspNetRoleRepository(ApplicationDbContext context,RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> Create(IdentityRole entity)
        {
            return await _roleManager.CreateAsync(entity);
        }

        public async Task<IdentityResult> Update(IdentityRole entity)
        {

            #region IDK What to do, EF is crazy, ship as it is for now
            //considering change to dapper idk
            //QUERY ONLY works with Management Studio

            //somehow is creating a new role and not updating
            //return await _roleManager.UpdateAsync(entity);
            //_context.Roles.Update(entity);
            //return await _context.SaveChangesAsync();

            //_context.Roles.FromSqlRaw($"UPDATE [dbo].[AspNetRoles] set [Name] = '{entity.Name}', " +
            //    $"[NormalizedName] = '{entity.NormalizedName}' WHERE Id= '{entity.Id}'");
            //return await _context.SaveChangesAsync();
            #endregion

            return await _roleManager.UpdateAsync(entity);
        }

        public async Task<IdentityResult> Delete(IdentityRole entity)
        {
            return await _roleManager.DeleteAsync(entity);
        }

        public async Task<IdentityRole> Get(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task<List<IdentityRole>> GetAll()
        {
            return await _roleManager.Roles.ToListAsync();
        }

       
    }
}
