using ClienteApiWebNetCore.Core;
using ClienteApiWebNetCore.Dtos;
using ClienteApiWebNetCore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Services
{
    public class ServicioCertificados : IServicioCertificados
    {
        private IServicioServidor _servicioServidor;
        public ServicioCertificados(IServicioServidor servicioServidor)
        {
            _servicioServidor = servicioServidor;
        }

        public async Task<List<CertificadoDTO>> BuscarCertificadosAsync()
        {
            var res = await _servicioServidor.GetAsync<List<CertificadoDTO>>("api/certificados");
            return res;

        }
    }
}
