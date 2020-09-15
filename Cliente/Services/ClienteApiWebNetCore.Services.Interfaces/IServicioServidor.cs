using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Core
{
    public interface IServicioServidor
    {
        Task<string> GetAsyncInterno(string uri);
    }
}
