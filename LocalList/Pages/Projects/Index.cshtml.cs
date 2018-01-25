using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocalList.Data;
using LocalList.Data.Model;

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

        public async Task OnGetAsync()
        {
            Project = await _context.Project.ToListAsync();
        }
    }
}
