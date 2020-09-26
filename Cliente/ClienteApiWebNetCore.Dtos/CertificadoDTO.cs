using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteApiWebNetCore.Dtos
{
    public class CertificadoDTO
    {
        public Guid CertificadoId { get; set; }
        public int NumeroCertificado { get; set; }
        public int NumeroEscalas { get; set; }

        //public List<Escala> Escalas { get; set; }
    }
}
