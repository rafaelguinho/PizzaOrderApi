using Microsoft.EntityFrameworkCore;
using PizzaOrderApi.Models;

namespace PizzaOrderApi.DataContext
{
    public class OrdersDBContext : DbContext
    {
        public OrdersDBContext(DbContextOptions<OrdersDBContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

    }
}
