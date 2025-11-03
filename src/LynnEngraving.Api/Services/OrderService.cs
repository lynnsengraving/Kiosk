using LynnEngraving.Api.Data;
using LynnEngraving.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LynnEngraving.Api.Services
{
    public class OrderService
    {
        private readonly AppDbContext _db;
        public OrderService(AppDbContext db) { _db = db; }

        public async Task<Order> CreateAsync(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public Task<Order?> GetAsync(int id) =>
            _db.Orders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.Id == id);
    }
}
