using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Modelo
{
    public class Certificado
    {
        public Guid CertificadoId { get; set; }
        public int NumeroEscalas { get; set; }

        public List<Escala> Escalas { get; set; }
    }
}
