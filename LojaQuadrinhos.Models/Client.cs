using System;
using System.ComponentModel.DataAnnotations;

namespace LojaQuadrinhos.Models
{

    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(80)]
        public string Email { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
