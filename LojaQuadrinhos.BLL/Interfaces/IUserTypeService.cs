using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IUserTypeService
    {
        Task<UserType> GetUserTypeAsync(int id);
        Task<int> CreateUserTypeAsync(UserType entity);
        Task<List<UserType>> GetAllUserTypeAsync();
        Task<int> UpdateUserTypeAsync(UserType entity);
        Task<int> DeleteUserTypeAsync(UserType entity);
    }
}
