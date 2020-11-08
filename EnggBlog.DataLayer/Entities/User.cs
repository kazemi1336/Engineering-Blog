using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnggBlog.DataLayer.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public int RoleId { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(40, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Name { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string Mobile { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(50, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string Password { get; set; }

        [Display(Name = "کد فعالسازی")]
        [MaxLength(6, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string Code { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }

        #region Relations

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }


        #endregion

    }
}
