using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.DataAccess.Repository;
using LojaQuadrinhos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{
    public class ClientService : IClientService<Client>
    {

        IClientRepository _repo;
        public ClientService(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Client>> GetAllClientAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<Client> GetClientAsync(int id)
        {
            var emp = await _repo.Get(id);
            if (emp != null) return emp;
            else return new Client();
        }


        public async Task<int> CreateClientAsync(Client entity)
        {
                return await _repo.Create(entity);
        }

        public async Task<int> UpdateClientAsync(Client entity)
        {
            return await _repo.Update(entity);
        }

        public async Task<int> DeleteClientAsync(Client entity)
        {
            return await _repo.Delete(entity);
        }

    }
}
