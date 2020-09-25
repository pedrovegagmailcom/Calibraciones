using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Modelo
{
    public class Medicion
    {
        public Guid MedicionId { get; set; }
        public int NumeroRepeticion { get; set; }
        public double Patron { get; set; }
        public double Mesurando { get; set; }

        public PuntoCalibracion PuntoCalibracion { get; set; }
    }
}
