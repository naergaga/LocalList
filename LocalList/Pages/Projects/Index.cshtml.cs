using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocalList.Data;
using LocalList.Data.Model;
using LocalList.Utilities.Model;

namespace LocalList.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly LocalList.Data.AppDbContext _context;

        public IndexModel(LocalList.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; }
        public PageOption PageOption { get; set; }

        public void OnGet(int? current,int? size,string q)
        {
            var po = new PageOption();
            po.Current = current ?? 1;
            po.Size = size ?? 5;
            int skipNum = (po.Current - 1) * po.Size;
            var query = _context.Project.Where(t=>string.IsNullOrEmpty(q) || t.Name.Contains(q) || t.Title.Contains(q) || t.Description.Contains(q));

            po.Count = query.Count();
            Project = query.Skip(skipNum).Take(po.Size).ToList();
            PageOption = po;
        }
    }
}
