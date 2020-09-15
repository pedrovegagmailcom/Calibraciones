using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.DTOS
{
    public class UsuarioSesionDTO
    {
        public Guid UsuarioId { get; set; }
        public string CodigoUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
