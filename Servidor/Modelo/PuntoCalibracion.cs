using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Modelo
{
    public class PuntoCalibracion
    {
        public Guid PuntoCalibracionId { get; set; }

        public Escala Escala { get; set; }
        public List<Medicion> Mediciones { get; set; }
    }
}
