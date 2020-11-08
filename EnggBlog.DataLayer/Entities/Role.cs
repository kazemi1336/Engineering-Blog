using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EnggBlog.DataLayer.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string Name { get; set; }

        #region Relations
        public virtual ICollection<User> Users { get; set; }
        #endregion
    }
}
