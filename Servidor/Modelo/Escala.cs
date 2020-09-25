using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Modelo
{
    public class Escala
    {
        public Guid EscalaId { get; set; }
        public int NumeroPuntosCalibracion { get; set; }
        public int NumeroRepeticiones { get; set; }
        public Certificado Certificado { get; set; }
        public List<PuntoCalibracion> PuntosCalibracion { get; set; }
    }
}
