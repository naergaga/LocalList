using LocalList.Data;
using LocalList.Data.Model;
using LocalList.Utilities.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalList.Utilities.ViewComponents
{
    public class TagViewComponent : ViewComponent
    {
        private AppDbContext _context;

        public TagViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public TagModel Tag { get; set; }

        public IViewComponentResult Invoke()
        {
            var tags = _context.Tag.ToList();
            Tag = new TagModel { Tags = tags };
            return View(Tag);
        }
    }


    public class TagModel
    {
        public List<Tag> Tags { get; set; }
    }
}
