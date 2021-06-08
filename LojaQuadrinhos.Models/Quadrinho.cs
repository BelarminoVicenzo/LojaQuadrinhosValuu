using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaQuadrinhos.Models
{
    public class Quadrinho
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        
        public string Name { get; set; }
        [Required]
        public int GenreId { get; set; }

        [Required]
        public int QuadrinhoStateId { get; set; }
        
        [Required]
        public int ChapterNumbers { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(GenreId))]
        public virtual QuadrinhoGenre Genre { get; set; }
        
        
        [ForeignKey(nameof(QuadrinhoStateId))]
        public virtual QuadrinhoState State { get; set; }

    }
}
