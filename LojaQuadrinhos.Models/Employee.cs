using System.ComponentModel.DataAnnotations;

namespace LojaQuadrinhos.Models
{

    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        
        [Required]
        [StringLength(80)]
        public string Email { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
