using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using institute_management.Data;
using institute_management.model;

namespace institute_management.Pages.course_pg
{
    public class CreateModel : PageModel
    {
        private readonly institute_management.Data.institute_managementContext _context;

        public CreateModel(institute_management.Data.institute_managementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public course course { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.course == null || course == null)
            {
                return Page();
            }

            _context.course.Add(course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
