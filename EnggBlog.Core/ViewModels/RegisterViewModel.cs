﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EnggBlog.Core.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(40, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Name { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string Mobile { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(50, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [MaxLength(50, ErrorMessage = "مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه های عبور با یکدیگر همخوانی ندارند")]
        public string Repassword { get; set; }
    }
}
