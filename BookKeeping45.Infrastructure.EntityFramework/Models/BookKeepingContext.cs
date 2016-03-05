using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BookKeeping45.Infrastructure.EntityFramework.Models.Mapping;
using BookKeeping45.Domain.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookKeeping45.Infrastructure.EntityFramework.Models
{
    public class BookKeepingContext : DbContext
    {
        static BookKeepingContext()
        {
            Database.SetInitializer<BookKeepingContext>(new CreateDatabaseIfNotExists<BookKeepingContext>());
        }

        public BookKeepingContext()
            : base("Name=BookKeepingContext")
        {
        }

        public DbSet<LegoSet> LegoSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.Configurations.Add(new LegoSetMap());
        }

    }
}
