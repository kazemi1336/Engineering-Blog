using System;
using System.Collections.Generic;
using System.Text;
using EnggBlog.DataLayer.Entities;
using EnggBlog.DataLayer.Context;
using EnggBlog.Core.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EnggBlog.Core.ViewModels;


namespace EnggBlog.Core.Services{

    public class TempService : ITemp
    {
        EnggBlogContext _context;

        public TempService(EnggBlogContext context)
        {
            _context = context;
        }
               
        public List<Category> ShowMainMenu()
        {
            return _context.Categories.ToList();
        }

        public Tuple<List<ShowProductListItemViewModel>, int> GetProducts(int pageId = 1, int take = 0, string filter = "", List<int> selectedCategory = null)
        {
            IQueryable<Product> result = _context.Products;

            if (take == 0)
                take = 8;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Name.Contains(filter) || c.LatinName.Contains(filter) || c.Tags.Contains(filter));
            }

            if (selectedCategory != null && selectedCategory.Any())
            {
                foreach (var categoryId in selectedCategory)
                {
                    result = result.Where(c => c.CatId == categoryId );
                }
            }

            int skip = (pageId - 1) * take;
            int pageCount = (int)Math.Ceiling(result.Select(c =>
                               new ShowProductListItemViewModel()
                               {
                                   Id = c.Id,
                                   Name = c.Name,
                                   LatinName = c.LatinName,
                                   ImgName = c.ImgName,
                                   Des = c.Des,
                                   RefreshDate = c.RefreshDate,
                                   Tags = c.Tags,
                                  
                               }).Count() / (double)take);


            var query = result.Select(c => new ShowProductListItemViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                LatinName = c.LatinName,
                ImgName = c.ImgName,
                Des = c.Des,
                RefreshDate = c.RefreshDate,
                Tags = c.Tags,
               
            }).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        public List<Category> GetAllCategory()
        {
            return _context.Categories.Include(g => g.Products).ToList();
        }

        public Product ShowProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public void UpdateProductsenn(int id)
        {
            Product p = _context.Products.Find(id);
            p.NumberSeen += 1;
            _context.SaveChanges();
        }

        public void UpdateDownloadNumber(int id)
        {
            ProductDownloadFile PD = _context.ProductDownloadFiles.Find(id);
            PD.NumberDownload += 1;
            _context.SaveChanges();
        }

        public ProductDownloadFile ShowDownloadFileById(int id)
        {
            return _context.ProductDownloadFiles.Find(id);
        }

        public List<ProductDownloadFile> ShowDownloadFile(int id)
        {
            return _context.ProductDownloadFiles.Where(p => p.ProductId == id).ToList();
        }

    }
}
