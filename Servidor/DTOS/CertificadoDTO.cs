using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.DTOS
{
    public class CertificadoDTO
    {
        public Guid CertificadoId { get; set; }
        public int NumeroCertificado { get; set; }
        public int NumeroEscalas { get; set; }
    }
}
