using ClienteApiWebNetCore.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Services.Interfaces
{
    public interface IServicioCertificados
    {
        Task<List<CertificadoDTO>> BuscarCertificadosAsync();
    }
}
