using System;
using System.Collections.Generic;
using System.Text;
using EnggBlog.DataLayer.Entities;
using EnggBlog.Core.ViewModels;

namespace EnggBlog.Core.Interfaces
{
    public interface ITemp
    {
        List<Category> ShowMainMenu(); 
        Tuple<List<ShowProductListItemViewModel>, int> GetProducts(int pageId = 1, int take = 0, string filter = "", List<int> selectedCategory = null);
        List<Category> GetAllCategory();
        Product ShowProductById(int id);
        void UpdateProductsenn(int id);
        void UpdateDownloadNumber(int id);
        ProductDownloadFile ShowDownloadFileById(int id);
        List<ProductDownloadFile> ShowDownloadFile(int id);      
    }
}
