using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using LocalList.Data.Services;
using LocalList.Utilities.Apps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LocalList.Pages.Apps
{
    public class ToStringModel : PageModel
    {

        public class IndexModel
        {
            [DisplayName("代码")]
            public string Code { get; set; }
        }

        [BindProperty]
        public IndexModel Model { get; set; }
        public string BuildString { get; set; }

        public void OnGet()
        {
            Model = new IndexModel();
        }

        public void OnPost([FromServices]ToStringService service)
        {
            BuildString = service.GetBuildStr(Model.Code);
            
        }
    }
}