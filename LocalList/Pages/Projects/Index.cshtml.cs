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
using System.Collections;

namespace LocalList.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly LocalList.Data.AppDbContext _context;

        public IndexModel(LocalList.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get; set; }
        public PageOption PageOption { get; set; }
        public List<int> FilterTags { get; set; }

        public void OnGet(int? current, int? size, string q, List<int> tags)
        {
            FilterTags = tags;

            var po = new PageOption();
            po.Current = current ?? 1;
            po.Size = size ?? 15;
            int skipNum = (po.Current - 1) * po.Size;

            IQueryable<Project> query;
            IQueryable<int> pidList=null;
            bool hasTag = tags.Count > 0;

            if (hasTag)
            {
                IQueryable<ProjectTag> projectList = _context.ProjectTag;
                foreach (var item in tags)
                {
                    projectList = projectList.Where(t => t.TagId == item);
                }
                pidList = projectList.Select(t => t.ProjectId);
            }

            query = from p in _context.Project
                         where (string.IsNullOrEmpty(q) || (p.Name.Contains(q) || p.Title.Contains(q) || p.Description.Contains(q) || p.Address.Contains(q)))
                         &&(!hasTag || pidList.Contains(p.Id))
                         orderby p.AddTime descending
                         select p;

            po.Count = query.Count();
            Project = query.Skip(skipNum).Take(po.Size).ToList();
            PageOption = po;
        }
    }
}
