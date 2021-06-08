using System.Threading.Tasks;

namespace LojaQuadrinhos.DataAccess.Interfaces
{
    public interface IGenericRepositoryUpdateAndDelete<T>
    {
        Task<int> Delete(T entity);
        Task<int> Update(T entity);
    }
}
