using LojaQuadrinhos.Models;

namespace LojaQuadrinhos.DataAccess.Interfaces
{
    public interface IQuadrinhoRepository : IGenericRepository<Quadrinho>, IGenericRepositoryUpdateAndDelete<Quadrinho>
    {
      
    }
}
