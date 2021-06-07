using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LojaQuadrinhos.Models;

namespace LojaQuadrinhos.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }


        public DbSet<QuadrinhoGenre> QuadrinhoGenre { get; set; }
        public DbSet<QuadrinhoState> QuadrinhoState { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Quadrinho> Quadrinho { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<UserType> UserType { get; set; }


    }
}
