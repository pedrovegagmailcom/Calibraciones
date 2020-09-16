

namespace ApiWebNetCore.Modelo
{
    
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Usuario 
    {
        [Key]
        public string CodigoUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
    }
}
