using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaQuadrinhos.Models
{
    public class QuadrinhoState
    {
        //(finished, ongoing, hiatus)

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(8)]
        public string Name { get; set; }

        public virtual ICollection<Quadrinho> Quadrinho { get; set; }

    }
}
