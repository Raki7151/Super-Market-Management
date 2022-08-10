using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Models
{
    public class UserMasterContext:DbContext
    {
        public UserMasterContext()
        {

        }
        public UserMasterContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<UserMaster> userMasters { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<CustomerDetails> CustomerDetail { get; set; }

        public DbSet<Product> products { get; set; }
        public DbSet<Vegetable> vegetables { get; set; }
        public DbSet<Dairy> dairies { get; set; }
        public DbSet<Bill> bills { get; set; }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SREYAK\SQLEXPRESS;Initial Catalog=SuperMarkeManagement;Integrated Security=true");
            //optionsBuilder.UseSqlServer("Data Source=tcp:wipro-rpsv.database.windows.net;Initial Catalog=marketportal;User ID=supermarketproject;Password=Supermarket@123");
        }
    }
}
