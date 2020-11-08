using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnggBlog.DataLayer.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام دسته")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string Name { get; set; }

        [Display(Name = "نام سردسته")]
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        public virtual Category Parent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
