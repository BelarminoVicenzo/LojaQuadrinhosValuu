using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IClientService<T>
    {
        Task<T> GetClientAsync(int id);
        Task<int> CreateClientAsync(T entity);
        Task<List<T>> GetAllClientAsync();
        Task<int> UpdateClientAsync(T entity);
        Task<int> DeleteClientAsync(T entity);
    }
}
