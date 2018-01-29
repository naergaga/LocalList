using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocalList.Data;
using LocalList.Data.Model;
using LocalList.Data.Services;

namespace LocalList.Pages.Projects
{
    public class EditModel : PageModel
    {
        private readonly LocalList.Data.AppDbContext _context;
        private readonly TagService _service;

        public EditModel(LocalList.Data.AppDbContext context,TagService service)
        {
            _context = context;
            _service = service;
        }

        [BindProperty]
        public Project Project { get; set; }
        [BindProperty]
        public List<int> TagId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project.SingleOrDefaultAsync(m => m.Id == id);

            if (Project == null)
            {
                return NotFound();
            }

            TagId = _service.GetTagId(Project.Id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var item = _context.Project.SingleOrDefault(t => t.Id == Project.Id);
            var tags = _service.GetTagId(Project.Id);
            //delete id
            _service.RemoveProjectTags(tags.Except(TagId));

            //add id
            _service.AddProjectTags(TagId.Except(tags),item.Id);

            if (item == null) return NotFound();

            item.Name = Project.Name;
            item.Title = Project.Title;
            item.Description = Project.Description;

            _context.Update(item);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
