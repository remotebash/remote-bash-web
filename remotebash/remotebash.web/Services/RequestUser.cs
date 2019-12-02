using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using remotebash.web.Models;
using remotebash.web.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace remotebash.web.Services
{
    public class RequestUser : IRequestUser
    {

        private readonly IRequestBase<User> requestBase;

        public RequestUser(IRequestBase<User> requestBase)
        {
            this.requestBase = requestBase;
        }

        public User GetUserById(long id)
        {
            return requestBase.SendGetPathVariableAsync("/search/users/", id.ToString());
        }

        public List<User> GetUsers()
        {
            return requestBase.SendGetAll("/search/users/");
        }

        public User Login(User user)
        {
            return requestBase.SendPostAsync("/user/login/", user);
        }

        public User Register(User user)
        {
            return requestBase.SendPostAsync("/register/users/", user);
        }
    }
}
