using Microsoft.EntityFrameworkCore;
using static Assignment4.Models.EF_model;

namespace Assignment4.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }

        public DbSet<ShortInterestList> ShortInterestList { get; set; }

        public DbSet<Book> Book { get; set; }

        public DbSet<Dividend> Dividend { get; set; }

        public DbSet<Price> Price { get; set; }

        public DbSet<Price> KeyStats { get; set; }
    }
}