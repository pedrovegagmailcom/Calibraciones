using ApiWebNetCore.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Repositorio
{
    public interface ISeguridadRepositorio
    {
        Task<UsuarioSesionDTO> BuscarPorPassworAsync(string codigoUsuario, string password);
    }
}
