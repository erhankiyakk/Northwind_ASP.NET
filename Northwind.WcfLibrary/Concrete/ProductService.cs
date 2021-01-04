using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities;
using Northwind.Bll.Concrete;
using Northwind.Dal.Abstract.IProduct;
using Northwind.Dal.Concrete.EntityFramework;
using System.ServiceModel;

namespace Northwind.WcfLibrary.Concrete
{
    public class ProductService : IProductService
    {
        
        //Instance Provider ile ezilecek
        private ProductManager productManager = new ProductManager(new EfProductDal());
        public void Add(Product product)
        {
            productManager.Add(product);
        }

        public void Delete(int productId)
        {
            productManager.Delete(productId);
        }

        public Product Get(int productId)
        {
            return productManager.Get(productId);
        }

        public List<Product> GetAll()
        {
            return productManager.GetAll();
        }

        public void Update(Product product)
        {
            productManager.Update(product);
        }
    }
}
