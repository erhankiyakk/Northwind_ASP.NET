using Northwind.Dal.Abstract;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Dal.Abstract.IProduct;
using System.Data;

namespace Northwind.Dal.Concrete.EntityFramework
{
    
    public class EfProductDal : IProductDal
    {
        private NorthwindContext northwindContext = new NorthwindContext();
        public void Add(Product product)
        {
            northwindContext.Products.Add(product);
            northwindContext.SaveChanges();
        }

        public void Delete(int productId)
        {
            northwindContext.Products.Remove(Get(productId));
            northwindContext.SaveChanges();
        }

        public Product Get(int productId)
        {
            return northwindContext.Products.FirstOrDefault(x => x.ProductID == productId);
        }

        public List<Product> GetAll()
        {
            return northwindContext.Products.ToList();
        }

        public void Update(Product product)
        {
            Product UpdateProduct = Get(product.ProductID);
            UpdateProduct.ProductName = product.ProductName;
            UpdateProduct.CategoryID = product.CategoryID;
            UpdateProduct.UnitPrice = product.UnitPrice;
            northwindContext.SaveChanges();
        }
    }
}
