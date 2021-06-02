using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Interfaces
{
    public interface IGenericRepositoryUpdateAnDelete<T> where T : class
    {
        Task<int> Delete(object entityId);
        Task<int> Update(object entityId);
    }

    public interface IGenericRepository<T>where T : class
    {

        Task Create(T entity);
        Task<T> Get(object id);
        Task<List<T>> GetAll();
      
      }
}
