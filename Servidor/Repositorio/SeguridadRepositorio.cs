using ApiWebNetCore.Context;
using ApiWebNetCore.Modelo;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Repositorio
{
    
    public class SeguridadRepositorio : ISeguridadRepositorio
    {
        private MainContext _contexto;
        private readonly IMapper _mapper;

        public SeguridadRepositorio(MainContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<UsuarioSesionDTO> BuscarPorPassworAsync(string codigoUsuario, string password)
        {
            var resultadoBBDD = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.CodigoUsuario == codigoUsuario && u.Password == Password.HashPassword(password + u.PkUsuario));
            return _mapper.Map<UsuarioSesionDTO>(resultadoBBDD);
        }

        private Usuario BuscarUsuarioPorPk(Guid pkUsuario)
        {

            return _contexto.Usuarios.Single(u => u.PkUsuario == pkUsuario);

        }
    }

}
