using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSX.Based.Common.Models
{
    public class User
    {
        public int Id { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("created_at")]
        public DateTime? UpdatedAt { get; set; }
    }

}
