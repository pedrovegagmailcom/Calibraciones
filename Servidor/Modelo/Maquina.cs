using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Modelo
{
    public class Maquina
    {
        public int MaquinaID { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<MaquinaCliente> Clientes { get; set; }
    }
}
