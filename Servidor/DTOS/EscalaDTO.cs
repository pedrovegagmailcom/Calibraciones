using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.DTOS
{
    public class EscalaDTO
    {
        public Guid EscalaId { get; set; }
        public int NumeroPuntosCalibracion { get; set; }
        public int NumeroRepeticiones { get; set; }
        public List<MedicionDTO> Mediciones { get; set; }
    }
}
