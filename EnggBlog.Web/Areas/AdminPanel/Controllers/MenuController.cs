using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using EnggBlog.Core.Interfaces;
using EnggBlog.DataLayer.Entities;

namespace EnggBlog.Web.Areas.AdminPanel.Controllers
{
    [Authorize]
    [Area("AdminPanel")]
  
    public class MenuController : Controller
    {
        private IAdmin _iadmin;
        public MenuController(IAdmin iadmin)
        {
            _iadmin = iadmin;
        }

       
        public IActionResult Index()
        {
            List<Category> categories = _iadmin.ShowCategory();
            return View(categories);
        }


        public IActionResult Create()
        {
            ViewBag.catId = new SelectList(_iadmin.ShowCategory(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                Category newcat = new Category()
                {
                    Name = cat.Name,
                    ParentId = cat.Id
                };
                _iadmin.AddCategory(newcat);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.catId = new SelectList(_iadmin.ShowCategory(), "Id", "Name");
                return View(cat);
            }
        }


        public IActionResult Edit(int id)
        {
            ViewBag.catId = new SelectList(_iadmin.ShowCategory(), "Id", "Name");
            Category catedit = _iadmin.ShowCategoryById(id);
            return View(catedit);
        }
        [HttpPost]
        public IActionResult Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                bool isedit = _iadmin.UpdateCategory(id, category.Name, category.ParentId);

                if (isedit)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(category);
                }
            }
            ViewBag.catId = new SelectList(_iadmin.ShowCategory(), "Id", "Name");
            return View(category);
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
                bool isdelete = _iadmin.RemoveCategory(id);

                if (isdelete)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}