using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TrainingProgram.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TrainingProgram.Persistance
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Program> Program { get; set; }
        public DbSet<Module> Module { get; set; }
    }
    
}
