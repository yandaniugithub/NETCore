using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yak.EFCore.DB.Model
{
    [Table("Sys_UserInfoDetails")]
    public class Sys_UserInfoDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        [MaxLength(200), Required]
        public string Email { get; set; }

        public virtual Sys_User Userinfo { get; set; }
    }
}
