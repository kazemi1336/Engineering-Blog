using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnggBlog.Core.Interfaces;

namespace EnggBlog.Web.ViewComponents.DownloadFileComponent
{
    public class DownloadFileComponent : ViewComponent
    {
        private ITemp _itemp;
        public DownloadFileComponent(ITemp itemp)
        {
            _itemp = itemp;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult((IViewComponentResult)View("ShowFileDown", _itemp.ShowDownloadFile(id)));
        }
    }
}
