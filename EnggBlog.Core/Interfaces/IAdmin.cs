using System;
using System.Collections.Generic;
using System.Text;
using EnggBlog.DataLayer.Entities;
using EnggBlog.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnggBlog.Core.Interfaces
{
    public interface IAdmin
    {        

        #region Category
        List<Category> ShowCategory();
        int AddCategory(Category category);
       
        bool RemoveCategory(int id);
        bool UpdateCategory(int id, string name, int? parentId);
        Category ShowCategoryById(int id);

        //------------------------------//
        List<SelectListItem> GetCategoryForManageProduct();
        #endregion

        #region product
        List<Product> ShowProduct();
        int AddProduct(Product product);
        bool RemoveProduct(int id);
        bool UpdateProduct(int id, int catId, string name,string latinName, string tags, string imgName, string des);
        Product ShowProductById(int id);
        Tuple<List<ShowProductForIndexViewModel>, int> ShowIndexProuduct(int pageId = 1, int take = 2);
        #endregion

        #region ProductDownloadFile
        List<ProductDownloadFile> ShowProductDownloadFile();
        int AddProductDownloadFile(ProductDownloadFile productDownloadFile);
        bool RemoveProductDownloadFile(int id);
        bool UpdateProductDownloadFile(int id, int productId, string name, string routeAddress, string volume,string sourceName, string authorName, string typeName, string fileFormat, string blogLang);
        ProductDownloadFile ShowProductDownloadFileById(int id);
        #endregion 
    }
}
