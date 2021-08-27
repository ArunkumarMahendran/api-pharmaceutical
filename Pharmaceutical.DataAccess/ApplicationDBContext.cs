using Microsoft.EntityFrameworkCore;
using Pharmaceutical.Common.Models;
using Pharmaceutical.DAL.Extension;


namespace Pharmaceutical.DataAccess
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        public DbSet<ContractDetail> ContractDetails { get; set; }

       // To feed initial data to SQL server
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedContractData();
        }

    }
}
