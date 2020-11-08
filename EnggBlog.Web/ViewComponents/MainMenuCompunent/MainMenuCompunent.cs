using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnggBlog.DataLayer.Context;
using EnggBlog.Core.Interfaces;
using EnggBlog.Core.Services;

namespace EnggBlog.Web.ViewComponents.MainMenuCompunent
{
    public class MainMenuCompunent : ViewComponent
    {
        private ITemp _itemp;
        public MainMenuCompunent(ITemp itemp)
        {
            _itemp = itemp;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ShowMenuSideBar", _itemp.GetAllCategory()));
        }
    }
}
