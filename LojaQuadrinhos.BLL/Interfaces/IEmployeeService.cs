using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IEmployeeService<T>
    {
        Task<T> GetEmployeeAsync(int id);
        Task<int> CreateEmployeeAsync(T entity);
        Task<List<T>> GetAllEmployeeAsync();
        Task<int> UpdateEmployeeAsync(T entity);
        Task<int> DeleteEmployeeAsync(T entity);
    }
}
