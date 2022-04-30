using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yak.EFCore.DB.Model
{
    [Table("Sys_User")]
    public class Sys_User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(50), Required]
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(50), Required]
        public string Password { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
        public virtual ICollection<Sys_UserInfoDetails> UserInfoDetails { get; set; }
    }
}
