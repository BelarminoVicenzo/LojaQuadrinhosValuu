using LojaQuadrinhos.DataAccess.Repository;
using LojaQuadrinhos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.BLL.Service
{


    public class QuadrinhoGenreService : IQuadrinhoGenreService<QuadrinhoGenre>
    {

        IQuadrinhoGenreRepository _repo;
        public QuadrinhoGenreService(IQuadrinhoGenreRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<QuadrinhoGenre>> GetAllGenreAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<QuadrinhoGenre> GetGenreAsync(int id)
        {
            var genre = await _repo.Get(id);
            if (genre != null) return genre;
            else return new QuadrinhoGenre();
        }


        public async Task<int> CreateGenreAsync(QuadrinhoGenre entity)
        {
                return await _repo.Create(entity);
        }

        public async Task<int> UpdateGenreAsync(QuadrinhoGenre entity)
        {
            return await _repo.Update(entity);
        }

        public async Task<int> DeleteGenreAsync(QuadrinhoGenre entity)
        {
            return await _repo.Delete(entity);
        }



        //....
        private int CheckIfGenreNameIsValid(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return 0;
            else return 1;
        }

    }
}
