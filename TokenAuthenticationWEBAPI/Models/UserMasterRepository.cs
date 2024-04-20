using System;
using System.Linq;

namespace TokenAuthenticationWEBAPI.Models
{
    public class UserRepository : IDisposable
    {
        public void Dispose()
        {
        }

        //This method is used to check and validate the user credentials
        public User ValidateUser(string username, string password)
        {
            UsersBL ubl = new UsersBL();
            return ubl.GetUsers().FirstOrDefault(user =>
            user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.Password == password);
        }
    }
}