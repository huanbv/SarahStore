using System;
using System.Collections.Generic;
using System.Linq;

namespace SarahStore.Models
{
    public class EFProductRepository : IProductRepository 
    {
        private ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;
    }
}
