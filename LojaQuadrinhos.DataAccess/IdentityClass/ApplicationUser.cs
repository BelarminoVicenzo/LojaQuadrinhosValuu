
using LojaQuadrinhos.Models;

using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations.Schema;

namespace LojaQuadrinhos.DataAccess
{
    public class ApplicationUser : IdentityUser
    {

     
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }

}
