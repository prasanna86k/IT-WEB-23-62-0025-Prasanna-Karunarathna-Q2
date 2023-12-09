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
    public class DetailsModel : PageModel
    {
        private readonly institute_management.Data.institute_managementContext _context;

        public DetailsModel(institute_management.Data.institute_managementContext context)
        {
            _context = context;
        }

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
    }
}
