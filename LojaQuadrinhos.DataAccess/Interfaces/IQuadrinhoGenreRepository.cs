using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

namespace LojaQuadrinhos.DataAccess.Interfaces
{
    public interface IQuadrinhoGenreRepository:IGenericRepository<QuadrinhoGenre>, IGenericRepositoryUpdateAndDelete<QuadrinhoGenre>
    {

    }
}
