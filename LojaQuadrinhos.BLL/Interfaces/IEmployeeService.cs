using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeAsync(int id);
        Task<int> CreateEmployeeAsync(Employee entity);
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<int> UpdateEmployeeAsync(Employee entity);
        Task<int> DeleteEmployeeAsync(Employee entity);
    }
}
