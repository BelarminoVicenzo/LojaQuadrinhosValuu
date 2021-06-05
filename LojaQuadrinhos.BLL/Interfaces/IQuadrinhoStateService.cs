using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IQuadrinhoStateService
    {
        Task<QuadrinhoState> GetStateAsync(int id);
        Task<int> CreateStateAsync(QuadrinhoState entity);
        Task<List<QuadrinhoState>> GetAllStateAsync();
        Task<int> UpdateStateAsync(QuadrinhoState entity);
        Task<int> DeleteStateAsync(QuadrinhoState entity);
    }
}
