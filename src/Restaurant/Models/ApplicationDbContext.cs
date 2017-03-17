using Microsoft.EntityFrameworkCore;//add this
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Restaurant.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

       public DbSet<Member> Members { get; set; }//add this

        public DbSet<Message> Messages { get; set; }//add this

        public DbSet<Menu1> Menu1s { get; set; }

        public DbSet<Menu2> Menu2s { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();
        }
    }
}
