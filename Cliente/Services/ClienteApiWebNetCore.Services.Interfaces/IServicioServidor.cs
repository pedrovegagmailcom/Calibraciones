using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Core
{
    public interface IServicioServidor
    {
        Task<string> GetAsync(string uri);
        Task<TDto> GetAsync<TDto>(string uri);
    }
}
