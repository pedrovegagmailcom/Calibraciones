using ApiWebNetCore.DTOS;
using System.Threading.Tasks;

namespace ApiWebNetCore.Repositorio
{
    public interface ISeguridadRepositorio
    {
        Task<UsuarioSesionDTO> BuscarAsync(string codigoUsuario, string password);
    }
}
