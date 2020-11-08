using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EnggBlog.Core.Interfaces;
using EnggBlog.DataLayer.Entities;
using EnggBlog.Core.Classes;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using MD.PersianDateTime.Core;

namespace EnggBlog.Web.Areas.AdminPanel.Controllers
{
    [Authorize]
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private IAdmin _iadmin;

        public ProductController(IAdmin iadmin)
        {
            _iadmin = iadmin;
        }


        public IActionResult Index(int pageId = 1, int take = 2)
        {
            if (pageId > 1)
            {
                ViewData["Take"] = (pageId - 1) * take + 1;
            }
            else
            {
                ViewData["Take"] = take;
            }

            ViewBag.PageId = pageId;
            //--------------------------
            
            var result = _iadmin.ShowIndexProuduct(pageId, take);
            return View("Index", result);
        }

     
        public IActionResult Create()
        {
            ViewBag.catId = new SelectList(_iadmin.ShowCategory(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product pro)
        {
            if (ModelState.IsValid)
            {
                if (pro.Img != null)
                {
                    string imgpath = "";
                    pro.ImgAddress = CodeGenerators.ProductCode() + Path.GetExtension(pro.Img.FileName);

                    imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/ImagesProduct/", pro.ImgAddress);

                    using (var stream = new FileStream(imgpath, FileMode.Create))
                    {
                        pro.Img.CopyTo(stream);
                    }

                    Product newpro = new Product()
                    {
                        CatId = pro.CatId,
                        Name = pro.Name,
                        ImgName = pro.ImgAddress,
                        LatinName=pro.LatinName,                       
                        Tags=pro.Tags,                        
                        Des=pro.Des,                        
                        RefreshDate = PersianDateTime.Now.ToString("dddd d MMMM yyyy"),
                        NumberSeen = 0,
                       
                    };

                    _iadmin.AddProduct(newpro);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Img", "لطفا یک تصویر انتخاب نمایید");
                }
            }
            else
            {
                ViewBag.catId = new SelectList(_iadmin.ShowCategory(), "Id", "Name");
                return View(pro);
            }

            return View(pro);
        }

    
        public IActionResult Edit(int id)
        {
            ViewBag.catId = new SelectList(_iadmin.ShowCategory(), "Id", "Name");
            Product proedit = _iadmin.ShowProductById(id);
            return View(proedit);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product pro)
        {
            if (ModelState.IsValid)
            {
                bool isedit = false;
                string NewImgAddress = "";

                if (pro.Img != null)
                {
                    string imgpath = "";
                    pro.ImgAddress = CodeGenerators.ProductCode() + Path.GetExtension(pro.Img.FileName);
                    imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/ImagesProduct/", pro.ImgAddress);

                    using (var stream = new FileStream(imgpath, FileMode.Create))
                    {
                        pro.Img.CopyTo(stream);
                    }
                    NewImgAddress = pro.ImgAddress;
                }
                else
                {
                    NewImgAddress = pro.ImgName;
                }

                isedit = _iadmin.UpdateProduct(id, pro.CatId, pro.Name, pro.LatinName, pro.Tags, NewImgAddress, pro.Des);

                if (isedit)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(pro);
                }
            }
            ViewBag.catId = new SelectList(_iadmin.ShowCategory(), "Id", "Name");
            return View(pro);
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
                bool isdelete = _iadmin.RemoveProduct(id);
                if (isdelete)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

       
        public IActionResult Detail(int id)
        {
            Product newdetail = _iadmin.ShowProductById(id);
            return View(newdetail);
        }
    }
}