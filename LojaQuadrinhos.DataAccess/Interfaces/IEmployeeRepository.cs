using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public interface IEmployeeRepository:IGenericRepository<Employee>, IGenericRepositoryUpdateAndDelete<Employee>
    {

    }
}
