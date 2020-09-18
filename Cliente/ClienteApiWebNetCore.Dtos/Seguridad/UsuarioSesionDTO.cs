using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteApiWebNetCore.Dtos.Seguridad
{
    public class UsuarioSesionDTO
    {

        public string CodigoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
