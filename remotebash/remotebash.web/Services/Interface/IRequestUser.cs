using remotebash.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace remotebash.web.Services.Interface
{
    public interface IRequestUser
    {
        User Login(User user);
        List<User> GetUsers();
        User GetUserById(long id);
        User Register(User user);
    }
}
