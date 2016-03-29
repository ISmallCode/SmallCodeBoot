using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCodeBoot.Models
{
    public class User
    {
        [Key]
        public Guid ID { set; get; }

        [MaxLength(20)]
        [Display(Name ="用户名")]
        [Required]
        public string Username { set; get; }

        [MaxLength(50)]
        [Display(Name = "密码")]
        [Required]
        public string Password { set; get; }

        [MaxLength(50)]
        [Display(Name = "邮箱")]
        public string Email { set; get; }

        public DateTime CreatedDate { set; get; }

        public bool IsDelete { set; get; }

        public Role Role { set; get; }
    }

    public enum Role { 一般管理员, 超级管理员 }
}