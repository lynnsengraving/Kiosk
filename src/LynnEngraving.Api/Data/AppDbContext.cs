using Microsoft.EntityFrameworkCore;
using LynnEngraving.Api.Models;

namespace LynnEngraving.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<NotificationLog> NotificationLogs => Set<NotificationLog>();
    }
}
