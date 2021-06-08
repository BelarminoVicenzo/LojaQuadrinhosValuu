using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{
    public class QuadrinhoService : IQuadrinhoService
    {

        IQuadrinhoRepository _repo;
        public QuadrinhoService(IQuadrinhoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Quadrinho>> GetAllQuadrinhosAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<Quadrinho> GetQuadrinhoAsync(int id)
        {
            var quad = await _repo.Get(id);
            if (quad != null) return quad;
            else return new Quadrinho();
        }


        public async Task<int> CreateQuadrinhoAsync(Quadrinho quadrinho)
        {
                return await _repo.Create(quadrinho);
        }

        public async Task<int> UpdateQuadrinhoAsync(Quadrinho quadrinho)
        {
            return await _repo.Update(quadrinho);
        }

        public async Task<int> DeleteQuadrinhoAsync(Quadrinho quadrinho)
        {
            return await _repo.Delete(quadrinho);
        }

    }
}
