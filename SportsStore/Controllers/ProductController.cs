using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 4;
        private IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int productPage = 1) => View(new ProductListViewModel
        {

            //Продукты
            Products = repository.Products
            .Where(x => category == null || x.Category == category)
            .OrderBy(p => p.ProductID)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize),

            //Информация о странице
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                // по-другому: if(category == null) {...} else {...}
                TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(x =>
                        x.Category == category).Count()
            },

            //Текущая категория
            CurrentCategory = category
        });
    }
}
