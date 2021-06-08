using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaQuadrinhos.Models
{
   public  class UserType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Type { get; set; }
    }
}
