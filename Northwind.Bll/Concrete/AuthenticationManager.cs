using Northwind.Dal;
using Northwind.Dal.Abstract.IAuthentication;
using Northwind.Entities.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        private IAuthenticationDal _authenticationDal;
        public AuthenticationManager(IAuthenticationDal _authenticationDal)
        {
            this._authenticationDal = _authenticationDal;
        }
        public User Authenticate(User user)
        {
            return _authenticationDal.Authenticate(user);
        }
    }
}
