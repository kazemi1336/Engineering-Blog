using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EnggBlog.DataLayer.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CatId { get; set; }

        [Display(Name = "نام فارسی")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string Name { get; set; }

        [Display(Name = "نام لاتین")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string LatinName { get; set; }

        [Display(Name = "کلمات کلیدی")]        
        public string Tags { get; set; }

        [Display(Name = "انتخاب تصویر")]
        [NotMapped]
        public IFormFile Img { get; set; }

        [NotMapped]
        public string ImgAddress { get; set; }

        [Display(Name = "تصویر شاخص ")]
        [MaxLength(100, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string ImgName { get; set; }

        [Display(Name = " توضیحات")]
        [DataType(DataType.MultilineText)]
        public string Des { get; set; }

        [Display(Name = "تاریخ ")]
        [MaxLength(100, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string RefreshDate { get; set; }

        [Display(Name = "تعداد بازدید ")]
        public int? NumberSeen { get; set; }

        [Display(Name = "نام سردسته")]
        [ForeignKey("CatId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductDownloadFile> ProductDownloadFiles { get; set; }
    }
}
