using Microsoft.EntityFrameworkCore;
using VerstaTestTask.Domain.Models;

namespace VerstaTestTask.DAL
{
    public class ApplicationDbContext: DbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<Order> Orders { get; set; }

    }
   
}
