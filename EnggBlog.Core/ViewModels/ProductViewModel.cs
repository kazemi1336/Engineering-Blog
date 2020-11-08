using System;
using System.Collections.Generic;
using System.Text;

namespace EnggBlog.Core.ViewModels
{
    public class ShowProductForIndexViewModel
    {  
        public int Id { get; set; }    
        public int CatId { get; set; }
        public string Name { get; set; }
        public string LatinName { get; set; }
        public string ImgAddress { get; set; }
        public string ImgName { get; set; } 
        public string Category { get; set; }
        public string Tags { get; set; }
        public string Des { get; set; }
        public string RefreshDate { get; set; }
        public int? NumberSeen { get; set; }       
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int ProductCount { get; set; }
    }

    public class ShowProductListItemViewModel
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        public string Name { get; set; }
        public string LatinName { get; set; }
        public string ImgName { get; set; }
        public string Tags { get; set; }
        public string Des { get; set; }        
        public string RefreshDate { get; set; } 

    }
}
