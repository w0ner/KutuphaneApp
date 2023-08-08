using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>().HasOne(x => x.Members).WithMany(x => x.Books).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                ID = 1,
                Name = "Öner",
                Surname = "Dağcı",
                Username = "oner",
                Password = "202cb962ac59075b964b07152d234b70"
            });
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}
