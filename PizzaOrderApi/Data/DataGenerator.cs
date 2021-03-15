using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzaOrderApi.DataContext;
using PizzaOrderApi.Models;
using System;
using System.Linq;

namespace PizzaOrderApi.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OrdersDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<OrdersDBContext>>()))
            {
                // Look for any board games already in database.
                if (context.Orders.Any())
                {
                    return;   // Database has been seeded
                }

                context.Orders.AddRange(
                    new Order
                    {
                        Id = 1,
                        Crust = "NORMAL",
                        Flavor = "CHICKEN-FAJITA",
                        Size = "L",
                        TableNo = 3,
                    },
                    new Order
                    {
                        Id = 2,
                        Crust = "NORMAL",
                        Flavor = "BEEF-NORMAL",
                        Size = "M",
                        TableNo = 5,
                    },
                    new Order
                    {
                        Id = 3,
                        Crust = "THIN",
                        Flavor = "CHEESE",
                        Size = "S",
                        TableNo = 2,
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
