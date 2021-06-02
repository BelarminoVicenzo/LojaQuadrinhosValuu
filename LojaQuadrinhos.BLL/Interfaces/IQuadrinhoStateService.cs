using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IQuadrinhoStateService<T>
    {
        Task<T> GetStateAsync(int id);
        Task<int> CreateStateAsync(T entity);
        Task<List<T>> GetAllStateAsync();
        Task<int> UpdateStateAsync(T entity);
        Task<int> DeleteStateAsync(T entity);
    }
}
