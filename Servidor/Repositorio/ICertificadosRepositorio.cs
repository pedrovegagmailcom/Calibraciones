using ApiWebNetCore.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Repositorio
{
    public interface ICertificadosRepositorio
    {
        Task<Guid> AgregarCertificado(CertificadoDTO certificadoDTO);
    }
}
