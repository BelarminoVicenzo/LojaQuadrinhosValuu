using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

namespace LojaQuadrinhos.DataAccess.Interfaces
{
    public interface IUserTypeRepository:IGenericRepository<UserType>, IGenericRepositoryUpdateAndDelete<UserType>
    {

    }
}
