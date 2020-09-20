using ClienteApiWebNetCore.Core;
using ClienteApiWebNetCore.Dtos.Seguridad;
using ClienteApiWebNetCore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Services
{
    public class ServicioUsuarios : IServicioUsuarios
    {
        private IServicioServidor _servicioServidor;
        public ServicioUsuarios(IServicioServidor servicioServidor)
        {
            _servicioServidor = servicioServidor;
        }

        public async Task<List<UsuarioSesionDTO>> BuscarUsuariosAsync()
        {
            var res = await _servicioServidor.GetAsync<List<UsuarioSesionDTO>>("api/Sesion");
            return res;

        }
    }
}
