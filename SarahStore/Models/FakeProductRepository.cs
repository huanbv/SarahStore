using System;
using System.Collections.Generic;
using System.Linq;

namespace SarahStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        IQueryable<Product> IProductRepository.Products => new List<Product>() {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surf board", Price = 179 },
            new Product { Name = "Running shoes", Price = 95 }
        }.AsQueryable<Product>();
    }
}
