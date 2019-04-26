using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;


        public void SaveProduct(Product product)
        {
            // Если это новый продукт
            if(product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            // Редактирование существующего
            else
            {
                Product dbEnrty = context.Products
                    .FirstOrDefault(x => x.ProductID == product.ProductID);
                if(dbEnrty != null)
                {
                    dbEnrty.Name = product.Name;
                    dbEnrty.Description = product.Description;
                    dbEnrty.Price = product.Price;
                    dbEnrty.Category = product.Category;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products
                .FirstOrDefault(p => p.ProductID == productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
