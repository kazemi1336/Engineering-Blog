using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EnggBlog.DataLayer.Entities
{
    public class ProductDownloadFile
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }


        [Display(Name = "عنوان لینک دانلود")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string Name { get; set; }

        [Display(Name = "مسیر فایل")]      
        public string RouteAddress { get; set; }

        [Display(Name = "نام منبع")]
        [MaxLength(200)]
        public string SourceName { get; set; }

        [Display(Name = "نام نویسندگان")]
        [MaxLength(200)]
        public string AuthorName { get; set; }

        [Display(Name = "نوع مطلب")]
        [MaxLength(100)]
        public string TypeName { get; set; }

        [Display(Name = "فرمت فایل")]
        [MaxLength(100)]
        public string FileFormat { get; set; }

        [Display(Name = "زبان")]
        [MaxLength(50, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string BlogLang { get; set; }

        [Display(Name = "حجم دانلود")]
        public string Volume { get; set; }

        [Display(Name = "تعداد دانلود")]
        public int NumberDownload { get; set; }

        [Display(Name = "مبلغ - تومان")]       
        public int ProductPrice { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

    }
}
