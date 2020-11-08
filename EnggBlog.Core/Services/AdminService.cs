using System;
using System.Collections.Generic;
using System.Text;
using EnggBlog.DataLayer.Entities;
using EnggBlog.DataLayer.Context;
using EnggBlog.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using EnggBlog.Core.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnggBlog.Core.Services
{
    public class AdminService : IAdmin
    {
        private EnggBlogContext _context;

        public AdminService(EnggBlogContext context)
        {
            _context = context;
        }

   

        public int AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category.Id;
        }

        public int AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public int AddProductDownloadFile(ProductDownloadFile productDownloadFile)
        {
            _context.ProductDownloadFiles.Add(productDownloadFile);
            _context.SaveChanges();
            return productDownloadFile.Id;
        }

        public List<SelectListItem> GetCategoryForManageProduct()
        {
            return _context.Categories.Where(g => g.ParentId == null)
            .Select(g => new SelectListItem()
            {
                Text = g.Name,
                Value = g.Id.ToString()
            }).ToList();
        }

        public bool RemoveCategory(int id)
        {
            var cat = _context.Categories.Find(id);

            if (cat != null)
            {
                _context.Categories.Remove(cat);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool RemoveProduct(int id)
        {
            var pro = _context.Products.Find(id);
            if (pro != null)
            {
                _context.Products.Remove(pro);
                _context.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool RemoveProductDownloadFile(int id)
        {
            var pro = _context.ProductDownloadFiles.Find(id);
            if (pro != null)
            {
                _context.ProductDownloadFiles.Remove(pro);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }         

        public List<Category> ShowCategory()
        {
            return _context.Categories.Include(c => c.Parent).ToList();
        }

        public Category ShowCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }


        public Tuple<List<ShowProductForIndexViewModel>, int> ShowIndexProuduct(int pageId = 1, int take = 2)
        {
            IQueryable<Product> result = _context.Products;

            int takeData = take;
            int skip = (pageId - 1) * takeData;
            int pageCount = (int)Math.Ceiling(result.Select(t =>
            new ShowProductForIndexViewModel()
            {
                Id = t.Id,
                Name = t.Name,
                LatinName = t.LatinName,
                Category = t.Category.Name,
                ImgName = t.ImgName,                          
                NumberSeen = t.NumberSeen,
               
            }).Count() / (double)takeData);

            var query = result.Select(s => new ShowProductForIndexViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                LatinName = s.LatinName,
                Category = s.Category.Name,                
                ImgName = s.ImgName,                
                NumberSeen =s.NumberSeen, 

            }).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        public List<Product> ShowProduct()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public Product ShowProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public List<ProductDownloadFile> ShowProductDownloadFile()
        {
            return _context.ProductDownloadFiles.Include(p => p.Product).ToList();
        }

        public ProductDownloadFile ShowProductDownloadFileById(int id)
        {
            return _context.ProductDownloadFiles.Find(id);
        }

      

        public bool UpdateCategory(int id, string name, int? parentId)
        {
            Category cat = _context.Categories.Find(id);
            if (cat != null)
            {
                cat.Name = name;
                cat.ParentId = parentId;
                _context.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool UpdateProduct(int id, int catId, string name, string latinName, string tags, string imgName, string des)
        {
            Product pro = _context.Products.Find(id);
            if (pro != null)
            {
                pro.CatId = catId;
                pro.Name = name;                
                pro.LatinName = latinName;                
                pro.Tags = tags;
                pro.ImgName = imgName;                
                pro.Des = des;                
                pro.RefreshDate = DateTime.Now.ToShortDateString();  
                
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProductDownloadFile(int id, int productId, string name, string authorName, string typeName, string fileFormat, string blogLang, string sourceName, string routeAddress, string volume)
        {
            ProductDownloadFile pro = _context.ProductDownloadFiles.Find(id);
            if (pro != null)
            {
                pro.ProductId = productId;
                pro.Name = name;
                pro.AuthorName = authorName;
                pro.TypeName = typeName;
                pro.FileFormat = fileFormat;
                pro.BlogLang = blogLang;
                pro.SourceName = sourceName; 
                pro.RouteAddress = routeAddress;
                pro.Volume = volume;

                _context.SaveChanges();
                return true;
            }
            else

            {
                return false;
            }
        }
    }
}
