using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interface;

namespace Northwind.WcfLibrary.Concrete
{
    public class CategoryService : ICategoryService
    {
        //Instance Provider ile ezilecek
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public List<Category> GetAll()
        {
            return categoryManager.GetAll();
        }
    }
}
