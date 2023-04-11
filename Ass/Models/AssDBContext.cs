using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace Ass.Models
{
    public class AssDBContext:DbContext
    {
        public AssDBContext()
        {
        }
        public AssDBContext(DbContextOptions options):base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MauSac> MauSacs { get; set; }
        public DbSet<ChatLieu> ChatLieus { get; set;}
        public DbSet<Team> Teams { get; set; }
        public DbSet<Bill> Bills { get; set; }  
        public DbSet<BillDetail> BillsDetail { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartsDetails { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=BAZAIZAI\\SQLEXPRESS;Initial Catalog=ASS_C#4;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
