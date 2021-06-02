using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public interface IQuadrinhoStateRepository:IGenericRepository<QuadrinhoState>, IGenericRepositoryUpdateAndDelete<QuadrinhoState>
    {

    }
}
