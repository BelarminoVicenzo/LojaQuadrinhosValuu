using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public interface ICustomerRepository:IGenericRepository<Customer>, IGenericRepositoryUpdateAndDelete<Customer>
    {

    }
}
