using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadReCreate.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Stdcategory> stdcategories { get; set; }
        public DbSet<Customer> customers { get; set; }
        
    }
}
