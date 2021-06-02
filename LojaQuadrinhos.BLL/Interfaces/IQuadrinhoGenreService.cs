using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IQuadrinhoGenreService<T>
    {
        Task<T> GetGenreAsync(int id);
        Task<int> CreateGenreAsync(T entity);
        Task<List<T>> GetAllGenreAsync();
        Task<int> UpdateGenreAsync(T entity);
        Task<int> DeleteGenreAsync(T entity);
    }
}
