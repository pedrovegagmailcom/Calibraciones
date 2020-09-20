using ClienteApiWebNetCore.Dtos.Seguridad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Services.Interfaces
{
    public interface IServicioUsuarios
    {
        Task<List<UsuarioSesionDTO>> BuscarUsuariosAsync();
    }
}
