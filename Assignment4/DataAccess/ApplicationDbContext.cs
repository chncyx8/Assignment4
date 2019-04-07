using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Assignment4.Models.EF_model;

namespace Assignment4.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Financials> Financials { get; set; }
    }
}