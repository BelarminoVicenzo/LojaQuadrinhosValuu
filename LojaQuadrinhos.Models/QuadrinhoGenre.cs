using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaQuadrinhos.Models
{
    public class QuadrinhoGenre
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Quadrinho> Quadrinho { get; set; }

    }
}
