using Deak_Levente_Ferenc_Lab9.Models;
using Microsoft.EntityFrameworkCore;

namespace Deak_Levente_Ferenc_Lab9.Data
{
    public class Deak_Levente_Ferenc_Lab9Context : DbContext
    {
        public Deak_Levente_Ferenc_Lab9Context (DbContextOptions<Deak_Levente_Ferenc_Lab9Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}
