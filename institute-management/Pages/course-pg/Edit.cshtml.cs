using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using institute_management.Data;
using institute_management.model;

namespace institute_management.Pages.course_pg
{
    public class EditModel : PageModel
    {
        private readonly institute_management.Data.institute_managementContext _context;

        public EditModel(institute_management.Data.institute_managementContext context)
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

            var course =  await _context.course.FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }
            course = course;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!courseExists(course.CourseID))
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

        private bool courseExists(int id)
        {
          return (_context.course?.Any(e => e.CourseID == id)).GetValueOrDefault();
        }
    }
}
