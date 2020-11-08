using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnggBlog.Core.Interfaces;
using EnggBlog.Core.Services;
using EnggBlog.DataLayer.Entities;

namespace EnggBlog.Web.Areas.AdminPanel.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}