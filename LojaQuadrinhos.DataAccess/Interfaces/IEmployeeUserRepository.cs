using LojaQuadrinhos.DataAccess.DTOs;
using LojaQuadrinhos.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public interface IEmployeeUserRepository
    {
        Task<int> Create(DTOEmployeeUser employeeUser);
        Task<int> Delete(DTOEmployeeUser employeeUser);
        Task<int> Update(DTOEmployeeUser employeeUser);
        Task<List<DTOEmployeeUser>> GetAll();
        Task<DTOEmployeeUser> Get(int id);
        
    }
}
