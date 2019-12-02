using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace remotebash.web.Services.Interface
{
    public interface IRequestBase<T>
    {
        string SendPostReturnStringAsync(string uri, T model);
        T SendPostAsync(string uri, T model);
        T SendGet(string uri);
        List<T> SendGetAll(string uri);
        T SendGetPathVariableAsync(string uri, string path);
        T SendPutAsync(string uri, T model);
        T SendDeleteAsync(string uri, T model);
    }
}
