using Domain;
using Domain.Interface;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class ApplicationDbContext : IdentityDbContext, IContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<RentBook> RentBooks { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            CheckUpdatedEntities();

            return await base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            CheckUpdatedEntities();

            return base.SaveChanges();
        }


        private void CheckUpdatedEntities()
        {
            var updatedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            if (updatedEntities.Any())
            {
                var now = DateTime.UtcNow;

                updatedEntities.Select(x => x.Entity as EntidadeBase).ToList().ForEach(x => x.DateUpdate = now);
            }
        }

    }
}
