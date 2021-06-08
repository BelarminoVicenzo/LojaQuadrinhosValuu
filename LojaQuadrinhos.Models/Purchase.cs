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
        public int QuadrinhoId { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public int PurchasedQuantity { get; set; }
       
        [Required]
        public string UserId { get; set; }
        

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(QuadrinhoId))]
        public virtual Quadrinho Quadrinho { get; set; }
    }
}
