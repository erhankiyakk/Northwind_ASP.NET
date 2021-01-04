using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.WcfLibrary.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {

        //Instance Provider ile ezilecek
        private AuthenticationManager authenticationManager = new AuthenticationManager(new EfAuthenticationDal());

        public User Authenticate(User user)
        {
            return authenticationManager.Authenticate(user);
        }
    }
}
