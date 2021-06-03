using LojaQuadrinhos.DataAccess.Interfaces;
using LojaQuadrinhos.Models;

namespace LojaQuadrinhos.DataAccess.Repository
{
    public interface IClientRepository:IGenericRepository<Client>, IGenericRepositoryUpdateAndDelete<Client>
    {

    }
}
