using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public interface IQuadrinhoGenreRepository:IGenericRepository<QuadrinhoGenre>, IGenericRepositoryUpdateAndDelete<QuadrinhoGenre>
    {

    }
}
