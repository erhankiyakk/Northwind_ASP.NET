using Northwind.Dal.Abstract.IAuthentication;
using Northwind.Entities;
using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfAuthenticationDal : IAuthenticationDal
    {

        public User Authenticate(User user)
        {
            //veritabanından alınacak
            if (user.UserName == "admin" && user.Password == "admin")
            {
                return user;
            }
            return null;
        }

        
    }
}
