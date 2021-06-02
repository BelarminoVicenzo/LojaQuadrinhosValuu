using LojaQuadrinhos.BLL;
using LojaQuadrinhos.DataAccess;
using LojaQuadrinhos.DataAccess.Repository;
using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LojaQuadrinhosValuu.IoC
{
    public class DependencyInjection
    {
        private readonly IConfiguration Configuration;
        public DependencyInjection(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void InjectDependencies(IServiceCollection services)
        {
            /* Entity Framework connString */
           

            services.AddScoped<IQuadrinhoGenreService<QuadrinhoGenre>, QuadrinhoGenreService>();
            services.AddScoped<IQuadrinhoGenreRepository, QuadrinhoGenreRepository>();

          
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LojaQuadrinhos")));
        }
    }







}