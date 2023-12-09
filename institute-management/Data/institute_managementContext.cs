using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using institute_management.model;

namespace institute_management.Data
{
    public class institute_managementContext : DbContext
    {
        public institute_managementContext (DbContextOptions<institute_managementContext> options)
            : base(options)
        {
        }

        public DbSet<institute_management.model.course> course { get; set; } = default!;

        public DbSet<institute_management.model.student>? student { get; set; }
    }
}
