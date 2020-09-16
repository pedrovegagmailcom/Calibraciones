using ClienteApiWebNetCore.Services.Interfaces.DTOS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Services.Interfaces
{
    public interface IServicioUsuarios
    {
        Task<List<UsuarioSesionDTO>> BuscarUsuariosAsync();
    }
}
