using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

namespace LojaQuadrinhos.DataAccess.Interfaces
{
    public interface IQuadrinhoStateRepository:IGenericRepository<QuadrinhoState>, IGenericRepositoryUpdateAndDelete<QuadrinhoState>
    {

    }
}
