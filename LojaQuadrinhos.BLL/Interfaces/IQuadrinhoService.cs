using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IQuadrinhoService
    {
        Task<Quadrinho> GetQuadrinhoAsync(int id);
        Task<int> CreateQuadrinhoAsync(Quadrinho quadrinho);
        Task<List<Quadrinho>> GetAllQuadrinhosAsync();
        Task<int> UpdateQuadrinhoAsync(Quadrinho quadrinho);
        Task<int> DeleteQuadrinhoAsync(Quadrinho quadrinho);
      
    }
}
