using System;
using System.Linq;

namespace SarahStore.Models
{
    public interface IProductRepository
    {
       public IQueryable<Product> Products { get; }
    }
}
