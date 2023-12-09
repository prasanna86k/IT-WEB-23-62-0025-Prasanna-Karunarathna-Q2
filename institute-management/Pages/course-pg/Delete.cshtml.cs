using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using institute_management.Data;
using institute_management.model;

namespace institute_management.Pages.course_pg
{
    public class DeleteModel : PageModel
    {
        private readonly institute_management.Data.institute_managementContext _context;

        public DeleteModel(institute_management.Data.institute_managementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public course course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.course == null)
            {
                return NotFound();
            }

            var course = await _context.course.FirstOrDefaultAsync(m => m.CourseID == id);

            if (course == null)
            {
                return NotFound();
            }
            else 
            {
                course = course;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.course == null)
            {
                return NotFound();
            }
            var course = await _context.course.FindAsync(id);

            if (course != null)
            {
                course = course;
                _context.course.Remove(course);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
