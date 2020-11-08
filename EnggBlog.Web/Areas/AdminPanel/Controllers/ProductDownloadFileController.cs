using EnggBlog.Core.Interfaces;
using EnggBlog.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;

namespace EnggBlog.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductDownloadFileController : Controller
    {
        private IAdmin _iadmin;
        public ProductDownloadFileController(IAdmin iadmin)
        {
            _iadmin = iadmin;
        }

        
        public IActionResult Index()
        {
            List<ProductDownloadFile> ProductD = _iadmin.ShowProductDownloadFile();
            return View(ProductD);
        }

       
        public IActionResult Create()
        {
            ViewBag.productId = new SelectList(_iadmin.ShowProduct(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDownloadFile pro)
        {
            //if (ModelState.IsValid)
            //{
                ProductDownloadFile newpro = new ProductDownloadFile()
                {
                    ProductId = pro.ProductId,
                    Name = pro.Name,
                    AuthorName = pro.AuthorName,
                    TypeName = pro.TypeName,
                    FileFormat = pro.FileFormat,
                    BlogLang = pro.BlogLang,                   
                    SourceName = pro.SourceName,
                    RouteAddress = pro.RouteAddress,
                    Volume = pro.Volume,
                    NumberDownload = 0                   
                };
                _iadmin.AddProductDownloadFile(newpro);
                return RedirectToAction("Index");
            //}
            //else
            //{
            //    ViewBag.productId = new SelectList(_iadmin.ShowProduct(), "Id", "Name");
            //    return View(pro);
            //}
        }

 
        public IActionResult Edit(int id)
        {
            ViewBag.productId = new SelectList(_iadmin.ShowProduct(), "Id", "Name");
            ProductDownloadFile proedit = _iadmin.ShowProductDownloadFileById(id);
            return View(proedit);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductDownloadFile pro)
        {
            //if (ModelState.IsValid)
            //{
                bool isedit = _iadmin.UpdateProductDownloadFile(id, pro.ProductId, pro.Name, pro.AuthorName, pro.TypeName, pro.FileFormat, pro.BlogLang, pro.SourceName, pro.RouteAddress, pro.Volume);
                if (isedit)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(pro);
                }
            //}
            //ViewBag.productId = new SelectList(_iadmin.ShowProduct(), "Id", "Name");
            //return View(pro);
        }


        public IActionResult Delete(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                bool isdelete = _iadmin.RemoveProductDownloadFile(id);
                if (isdelete)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}