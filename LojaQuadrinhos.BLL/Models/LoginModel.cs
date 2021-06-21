using System;
using System.Collections.Generic;
using System.Text;

namespace LojaQuadrinhos.BLL.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
    
    public class UserRoleModel
    {

        public string RoleId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        
    }
}
