using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Dal.Abstract;
using Northwind.Entities;

namespace Northwind.Dal.Abstract.ICategory
{
    public interface ICategoryDal
    {
        List<Category> GetAll();
    }
}
