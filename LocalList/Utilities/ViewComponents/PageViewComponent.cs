using LocalList.Utilities.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalList.Utilities.ViewComponents
{
    public class PageViewComponent : ViewComponent
    {

        public PageViewComponent()
        {

        }

        public IViewComponentResult Invoke(PageOptionModel model)
        {
            return View(model);
        }
    }
}
