using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
        {
        }

        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("server=.;database=LibraryDb;trusted_connection=true;");
            }
        }
        //TODO: write DbSets for entities
        public DbSet<Book> Books { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<ReaderProfile> ReaderProfiles { get; set; }
    }
}