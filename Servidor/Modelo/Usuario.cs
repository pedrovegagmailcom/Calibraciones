

namespace ApiWebNetCore.Modelo
{
    
    using System;
    
    public class Usuario 
    {
        
        public Guid UsuarioId { get; set; }
        public string CodigoUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
    }
}
