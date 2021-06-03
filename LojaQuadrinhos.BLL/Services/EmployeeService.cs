using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.DataAccess.Repository;
using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{
    public class EmployeeService : IEmployeeService<Employee>
    {

        IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            var emp = await _repo.Get(id);
            if (emp != null) return emp;
            else return new Employee();
        }


        public async Task<int> CreateEmployeeAsync(Employee entity)
        {
                return await _repo.Create(entity);
        }

        public async Task<int> UpdateEmployeeAsync(Employee entity)
        {
            return await _repo.Update(entity);
        }

        public async Task<int> DeleteEmployeeAsync(Employee entity)
        {
            return await _repo.Delete(entity);
        }

    }
}
