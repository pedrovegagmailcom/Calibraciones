using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Modelo
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }

        public virtual ICollection<MaquinaCliente> Maquinas { get; set; }
    }
}
