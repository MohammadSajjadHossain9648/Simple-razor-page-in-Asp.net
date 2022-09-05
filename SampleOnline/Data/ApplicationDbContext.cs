using Microsoft.EntityFrameworkCore;
using SampleOnline.Model;

namespace SampleOnline.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        public DbSet<Category> Category { get; set; } //create table in database by DbSet<model_class_name> Table_name
    }
}
