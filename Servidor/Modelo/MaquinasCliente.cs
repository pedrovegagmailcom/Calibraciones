using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Modelo
{
    public class MaquinaCliente
    {
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        public int MaquinaID { get; set; }
        public Maquina Maquina { get; set; }
    }
}
