using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EnggBlog.Core.ViewModels
{
    public class InformationUserViewModel
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int Wallet { get; set; }

    }
    public class EditProfileViewModel
    {

        [Display(Name = "نام")]
        public string Name { get; set; }
        public string Mobile { get; set; }
    }

}
