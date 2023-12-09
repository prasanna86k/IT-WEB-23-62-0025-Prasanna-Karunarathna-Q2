using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using institute_management.Data;
using institute_management.model;

namespace institute_management.Pages.student_pg
{
    public class DeleteModel : PageModel
    {
        private readonly institute_management.Data.institute_managementContext _context;

        public DeleteModel(institute_management.Data.institute_managementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public student student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.student == null)
            {
                return NotFound();
            }

            var student = await _context.student.FirstOrDefaultAsync(m => m.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                student = student;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.student == null)
            {
                return NotFound();
            }
            var student = await _context.student.FindAsync(id);

            if (student != null)
            {
                student = student;
                _context.student.Remove(student);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
