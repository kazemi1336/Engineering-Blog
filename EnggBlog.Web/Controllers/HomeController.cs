
using EnggBlog.Core.Interfaces;
using EnggBlog.Core.ViewModels;
using EnggBlog.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;


namespace EnggBlog.Web.Controllers
{

    public class HomeController : Controller
    {
        
        private ITemp _itemp;
        
        public HomeController(ITemp itemp)
        {
            
            _itemp = itemp;
            
        }
        public IActionResult Index(int pageId = 1, int take = 0, string filter = "", List<int> selectedCategory = null)
        {

            ViewBag.Categors = _itemp.GetAllCategory();
            ViewBag.PageId = pageId;
            //--------------------------            
            ViewBag.SelectedCategory = selectedCategory;

            var result = _itemp.GetProducts(pageId, 4, filter, selectedCategory);
            return View("Index", result);
           
        }

        [Route("DetailP/{id}/{title}")]
        public IActionResult DetailP(int id, string title)
        {
            Product p = _itemp.ShowProductById(id);

            _itemp.UpdateProductsenn(id);
            return View(p);
        }

        public IActionResult UpdateDownloadFiles(int id)
        {
            ProductDownloadFile PD = _itemp.ShowDownloadFileById(id);
            _itemp.UpdateDownloadNumber(id);
            return Redirect(PD.RouteAddress);
        }

    }
}