using ApiWebNetCore.DTOS;
using System;
using System.Threading.Tasks;

namespace ApiWebNetCore.Repositorio
{
    public interface ISeguridadRepositorio
    {
        Task<UsuarioSesionDTO> BuscarAsync(string codigoUsuario);
    }
}
