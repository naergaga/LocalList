using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocalList.Data;
using LocalList.Data.Model;

namespace LocalList.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly LocalList.Data.AppDbContext _context;

        public CreateModel(LocalList.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Project.AddTime = DateTime.Now;
            _context.Project.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}