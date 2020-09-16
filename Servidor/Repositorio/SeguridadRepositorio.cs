using ApiWebNetCore.Context;
using ApiWebNetCore.DTOS;
using ApiWebNetCore.Modelo;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Repositorio
{
    
    public class SeguridadRepositorio : ISeguridadRepositorio
    {
        private MainContext _contexto;
        private readonly IMapper _mapper;

        public SeguridadRepositorio(MainContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public async Task<UsuarioSesionDTO> BuscarAsync(string codigoUsuario)
        {
            var resultadoBBDD = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.CodigoUsuario == codigoUsuario);
            return _mapper.Map<UsuarioSesionDTO>(resultadoBBDD);
        }

        
    }

}
