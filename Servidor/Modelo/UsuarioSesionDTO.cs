using System;
using System.Collections.Generic;

namespace ApiWebNetCore.Modelo
{
    public class UsuarioSesionDTO
    {
        public Guid PkUsuario { get; set; }
        public string CodigoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
