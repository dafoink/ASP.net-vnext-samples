using Microsoft.Data.Entity;
using MvcSample.Web.Models;
  
namespace MvcSample.DB{
    public class MyDbContext : DbContext
    {
        
        public DbSet<User> Messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Data Source=./test.db");
            
        }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Key(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
} 