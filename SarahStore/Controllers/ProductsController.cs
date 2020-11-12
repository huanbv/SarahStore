using System;
using Microsoft.AspNetCore.Mvc;
using SarahStore.Models;
using System.Linq;
using SarahStore.Models.ViewModels;

namespace SarahStore.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductsController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products.Where(p => category == null || p.Category == category).OrderBy(p => p.ProductId).Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrenPage = productPage,ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}
