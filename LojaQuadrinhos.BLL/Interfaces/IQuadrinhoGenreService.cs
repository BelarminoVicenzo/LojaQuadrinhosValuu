using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IQuadrinhoGenreService<T>
    {
        Task<T> GetGenreAsync(int id);
        Task<int> CreateGenreAsync(QuadrinhoGenre entity);
        Task<List<QuadrinhoGenre>> GetAllGenreAsync();
        Task<int> UpdateGenreAsync(QuadrinhoGenre entity);
        Task<int> DeleteGenreAsync(QuadrinhoGenre entity);
    }
}
