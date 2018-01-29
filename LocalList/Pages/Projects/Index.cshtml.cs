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
            po.Size = size ?? 5;
            int skipNum = (po.Current - 1) * po.Size;
            //tag Id 对应的 project Id
            var projectId = from t in _context.Tag
                         join pt in _context.ProjectTag on t.Id equals pt.TagId
                         where tags.Contains(t.Id)
                         select pt.ProjectId;

            var query = from p in _context.Project
                        //是否包含关键字
                         where (string.IsNullOrEmpty(q) || (p.Name.Contains(q) || p.Title.Contains(q) || p.Description.Contains(q)))
                         //不查询标签或 项目Id为
                         && (tags.Count == 0 || projectId.Contains(p.Id))
                         select p;
            po.Count = query.Count();
            Project = query.Skip(skipNum).Take(po.Size).ToList();
            PageOption = po;
        }
    }
}
