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
        public int EmployeeId { get; set; }
        
        [Required]
        public int ClientId { get; set; }
        
        [Required]
        public int QuadrinhoId { get; set; }
        
        [Required]
        public DateTime PurchaseDate { get; set; }


        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }


        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; }


        [ForeignKey(nameof(QuadrinhoId))]
        public virtual QuadrinhoGenre Genre { get; set; }
    }
}
