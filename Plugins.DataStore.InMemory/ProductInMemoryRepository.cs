using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;
using UseCases.PluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;

        public ProductInMemoryRepository() {
            products = new List<Product>()
            {
                 new Product {ProductId=1,CategoryId=1,Name="Queijo",Quantity=120,Price=3.00},
                 new Product {ProductId=2,CategoryId=1,Name="Achocolatado",Quantity=130,Price=4.00},
                 new Product {ProductId=3,CategoryId=2,Name="Refrigerante",Quantity=110,Price=6.00},
        };
        }
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;
            var maxId = products.Max(x => x.ProductId);
            product.ProductId = maxId + 1;
            products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);
            if (productToUpdate != null) productToUpdate = product;
        }
        public Product GetProductById(int productId)
        {
            return products?.FirstOrDefault(x => x.ProductId == productId);
        }
        public void DeleteProduct(int productId)
        {
            products?.Remove(GetProductById(productId));
        }
    }
}