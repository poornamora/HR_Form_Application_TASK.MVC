using First_Sample_Project.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace First_Sample_Project.Models
{
    public class ApplicationUser:DbContext
    {
        public ApplicationUser(DbContextOptions<ApplicationUser> options):base(options)
        {
            
        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                if(entry.Entity is ISoftDelete entity && entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entity.IsActive = false;
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRegistration>().Ignore(x => x.ConformPassword);
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<UserRegistration> UserRegistration { get; set; }
        
        public DbSet<FilesViewModel> filesViewModels {  get; set; } 

        public DbSet<HRFormModel> HRFormModels { get; set; }

        public DbSet<Country> countries { get; set; }
        public DbSet<City> cities { get; set; }

       


        public List<UserRegistration> SP_UsersList()
        {
            return UserRegistration.FromSqlRaw("EXECUTE [dbo].[SP_GetUsersList]").ToList();
        }

    }
}
