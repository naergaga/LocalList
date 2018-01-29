using LocalList.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalList.Data.Services
{
    public class TagService
    {
        private AppDbContext _context;

        public TagService(AppDbContext context)
        {
            _context = context;
        }

        public List<int> GetTagId(int projectId)
        {
            var query = from t in _context.Tag
                        join pt in _context.ProjectTag on t.Id equals pt.TagId
                        join p in _context.Project on pt.ProjectId equals p.Id
                        where p.Id==projectId
                        select t.Id;
            return query.ToList();
        }

        public void RemoveProjectTags(IEnumerable<int> idList)
        {
            var query = _context.ProjectTag.Where(t => idList.Contains(t.TagId));
            _context.RemoveRange(query);
            _context.SaveChanges();
        }

        public void AddProjectTags(IEnumerable<int> idList,int projectId)
        {
            var porjectTagList = idList.Select(t => new ProjectTag { TagId = t, ProjectId = projectId });
            _context.AddRange(porjectTagList);
            _context.SaveChanges();
        }
    }
}
