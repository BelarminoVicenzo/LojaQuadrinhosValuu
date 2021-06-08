using System.Collections.Generic;
using System.Threading.Tasks;


namespace LojaQuadrinhos.DataAccess.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<int> Create(T entity);
        Task<T> Get(object id);
        Task<List<T>> GetAll();
    }
}