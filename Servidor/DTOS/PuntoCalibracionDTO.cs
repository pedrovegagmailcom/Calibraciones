using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.DTOS
{
    public class PuntoCalibracionDTO
    {
        public Guid PuntoCalibracionId { get; set; }

        public EscalaDTO Escala { get; set; }
        public List<MedicionDTO> Mediciones { get; set; }
    }
}
