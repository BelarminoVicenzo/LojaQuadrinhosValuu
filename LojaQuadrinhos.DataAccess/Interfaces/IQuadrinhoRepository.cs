using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public interface IQuadrinhoRepository : IGenericRepository<Quadrinho>, IGenericRepositoryUpdateAndDelete<Quadrinho>
    {
      
    }
}
