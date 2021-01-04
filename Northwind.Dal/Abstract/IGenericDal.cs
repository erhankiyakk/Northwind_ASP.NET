using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetAll();

        T Get(int productId);

        void Add(T product);

        void Delete(int productId);

        void Update(T product);
    }
}
