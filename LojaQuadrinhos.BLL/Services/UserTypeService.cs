using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{


    public class UserTypeService : IUserTypeService
    {

        IUserTypeRepository _repo;
        public UserTypeService(IUserTypeRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<UserType>> GetAllUserTypeAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<UserType> GetUserTypeAsync(int id)
        {
            var type = await _repo.Get(id);
            if (type != null) return type;
            else return new UserType();
        }


        public async Task<int> CreateUserTypeAsync(UserType entity)
        {
                return await _repo.Create(entity);
        }

        public async Task<int> UpdateUserTypeAsync(UserType entity)
        {
            return await _repo.Update(entity);
        }

        public async Task<int> DeleteUserTypeAsync(UserType entity)
        {
            return await _repo.Delete(entity);
        }

    }
}
