using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> { 
                new Product{ProductId=1,CategoryId=1,ProductName="Glass",UnitPrice=3,UnitsInStock=15},
                new Product{ProductId=1,CategoryId=1,ProductName="Chair",UnitPrice=13,UnitsInStock=43},
                new Product{ProductId=1,CategoryId=1,ProductName="Fork",UnitPrice=1,UnitsInStock=12},
                new Product{ProductId=1,CategoryId=1,ProductName="Keyboard",UnitPrice=5,UnitsInStock=13},
                new Product{ProductId=1,CategoryId=1,ProductName="Mouse",UnitPrice=4,UnitsInStock=20}
            };
        }         
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
          Product  productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            product.UnitsInStock = product.UnitsInStock;

        }
    }
}
