using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EnggBlog.Core.ViewModels
{
    public class UpdateImgViewModel
    {
        [Display(Name = "انتخاب تصویر ")]
        [NotMapped]
        public IFormFile Img { get; set; }
        [NotMapped]
        public string ImgAddress { get; set; }

        [Display(Name = "نام شرکت")]
        [MaxLength(100, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string Name { get; set; }

        [Display(Name = "نام شرکت لاتین")]
        [MaxLength(100, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string LatinName { get; set; }

        [Display(Name = "مدیر عامل شرکت")]
        [MaxLength(100, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string CompanyManager { get; set; }

        [Display(Name = "آدرس پستی شرکت")]
        [MaxLength(200, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string CompanyAddress { get; set; }

        [Display(Name = "تلفن شرکت")]
        [MaxLength(200, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string CompanyTel { get; set; }

        [Display(Name = "آدرس سایت شرکت")]
        public string WebSiteLink { get; set; }

        [Display(Name = "فعالیت شرکت")]
        [MaxLength(1500, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string CompanyActivity { get; set; }

        [Display(Name = "پروژه های شرکت")]
        [MaxLength(1500, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string CompanyProjects { get; set; }

        [Display(Name = "رتبه و رشته شرکت")]
        [MaxLength(500, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string CompanyGrade { get; set; }
    }
}
