using Microsoft.EntityFrameworkCore;
using SPE.DataModel.Entities;
using System.Reflection;

namespace SPE.DataModel.Context
{
    public class SPEDbContext : DbContext
    {
        public SPEDbContext(DbContextOptions<SPEDbContext> context)
            :base(context)
        {

        }

        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*Through reflection, all classes that implement IEntityTypeConfiguration
             are scan and register each one automatically*/
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
