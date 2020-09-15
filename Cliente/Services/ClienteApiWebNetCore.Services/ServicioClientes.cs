using ClienteApiWebNetCore.Core;
using ClienteApiWebNetCore.Services.Interfaces;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Services
{
    public class ServicioClientes : IServicioClientes
    {
        private IServicioServidor _servicioServidor;
        public ServicioClientes(IServicioServidor servicioServidor)
        {
            _servicioServidor = servicioServidor;
        }

        public async Task<string> GetMessage()
        {
             var res = await _servicioServidor.GetAsyncInterno("api/clientes");
             return res;
            
        }
    }
}
