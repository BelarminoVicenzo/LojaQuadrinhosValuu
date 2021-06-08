using LojaQuadrinhos.BLL;
using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.BLL.Service;
using LojaQuadrinhos.DataAccess;
using LojaQuadrinhos.DataAccess.Interfaces;
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
           

            services.AddScoped<IQuadrinhoGenreService, QuadrinhoGenreService>();
            services.AddScoped<IQuadrinhoGenreRepository, QuadrinhoGenreRepository>();
            
            services.AddScoped<IQuadrinhoStateService, QuadrinhoStateService>();
            services.AddScoped<IQuadrinhoStateRepository, QuadrinhoStateRepository>();
            
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IQuadrinhoService, QuadrinhoService>();
            services.AddScoped<IQuadrinhoRepository, QuadrinhoRepository>();
            
            services.AddScoped<IUserTypeService, UserTypeService>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();

          
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LojaQuadrinhos")));
        }
    }







}