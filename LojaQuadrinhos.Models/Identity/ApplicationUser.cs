using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaQuadrinhos.Models
{
    public class ApplicationUser : IdentityUser
    {

     
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        
        public int UserTypeId { get; set; }

        [ForeignKey("UserTypeId")]
        public virtual UserType UserType { get; set; }

    }

}
