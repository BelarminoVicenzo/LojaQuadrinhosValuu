using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaQuadrinhos.Models
{


    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        public int QuadrinhoId { get; set; }
        
        [Required]
        public int PurchasedQuantity { get; set; }
        
        [Required]
        public DateTime PurchaseDate { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(QuadrinhoId))]
        public virtual Quadrinho Quadrinho { get; set; }
    }
}
