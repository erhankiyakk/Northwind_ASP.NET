using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Dal.Abstract.ICategory;
using Northwind.Entities;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        NorthwindContext northwindContext = new NorthwindContext();
        public List<Category> GetAll()
        {
            return northwindContext.Categories.ToList();
        }
    }
}
