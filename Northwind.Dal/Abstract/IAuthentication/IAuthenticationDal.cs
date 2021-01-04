using Northwind.Entities.Models;

namespace Northwind.Dal.Abstract.IAuthentication
{
    public interface IAuthenticationDal
    {
        User Authenticate(User user);
    }
}