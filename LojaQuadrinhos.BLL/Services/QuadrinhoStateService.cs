using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.DataAccess.Repository;
using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{


    public class QuadrinhoStateService : IQuadrinhoStateService
    {

        IQuadrinhoStateRepository _repo;
        public QuadrinhoStateService(IQuadrinhoStateRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<QuadrinhoState>> GetAllStateAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<QuadrinhoState> GetStateAsync(int id)
        {
            var state = await _repo.Get(id);
            if (state != null) return state;
            else return new QuadrinhoState();
        }


        public async Task<int> CreateStateAsync(QuadrinhoState entity)
        {
                return await _repo.Create(entity);
        }

        public async Task<int> UpdateStateAsync(QuadrinhoState entity)
        {
            return await _repo.Update(entity);
        }

        public async Task<int> DeleteStateAsync(QuadrinhoState entity)
        {
            return await _repo.Delete(entity);
        }

    }
}
