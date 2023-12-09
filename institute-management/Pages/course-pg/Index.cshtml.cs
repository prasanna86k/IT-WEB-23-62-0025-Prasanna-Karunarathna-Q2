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
    public class IndexModel : PageModel
    {
        private readonly institute_management.Data.institute_managementContext _context;

        public IndexModel(institute_management.Data.institute_managementContext context)
        {
            _context = context;
        }

        public IList<course> course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.course != null)
            {
                course = await _context.course.ToListAsync();
            }
        }
    }
}
