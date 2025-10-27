using Microsoft.EntityFrameworkCore;
using DialysisCRM.API.Models;

namespace DialysisCRM.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
    }
}