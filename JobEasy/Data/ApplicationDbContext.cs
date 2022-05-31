using JobEasy.Models;
using Microsoft.EntityFrameworkCore;

namespace JobEasy.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<JobList> JobLists { get; set; }
    }
}
