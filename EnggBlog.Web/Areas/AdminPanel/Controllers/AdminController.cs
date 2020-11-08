using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnggBlog.Core.Services;
using EnggBlog.Core.Interfaces;
using EnggBlog.DataLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnggBlog.Areas.AdminPanel.Controllers
{
    [Authorize]
    [Area("AdminPanel")]
    public class AdminController : Controller
    {
        //private IAdmin _iadmin;

        //public AdminController(IAdmin iadmin)
        //{
        //    _iadmin = iadmin;
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}