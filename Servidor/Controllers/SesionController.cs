using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using ApiWebNetCore.Modelo;
using ApiWebNetCore.Repositorio;
using AutoMapper;
using GL2017.API.Utilidades;
using ApiWebNetCore.Seguridad;
using ApiWebNetCore.DTOS;

namespace GL2017.API.Controladores.Seguridad
{
    [Produces("application/json")]
    [Route("api/Sesion")]
    public class SesionController : Controller
    {
        ISeguridadRepositorio _seguridadRepositorio;
        private readonly IMapper _mapper;

        public SesionController(ISeguridadRepositorio seguridadRepositorio, IMapper mapper)
        {
            _seguridadRepositorio = seguridadRepositorio;
            _mapper = mapper;
        }

        public async Task<UsuarioSesionDTO> BuscarUsuarioAsync(Guid codigoUsuario)
        {
            
            var usuario = await _seguridadRepositorio.BuscarAsync(codigoUsuario);
            if (usuario != null)
            {
                var usuarioSesion = _mapper.Map<UsuarioSesionDTO, UsuarioSesionDTO>(usuario);
                return usuarioSesion;
                
            }
            return null;
        }

        [HttpGet()]
        public async Task<IActionResult> CrearSesion(Guid codigoUsuario, string hostName, Guid aplicationID)
        {
            if (codigoUsuario == Guid.Empty)
            {
                return BadRequest();
            }
            var usuario = await BuscarUsuarioAsync(codigoUsuario);
            if (usuario != null)
            {
                usuario.Token = UtilidadesToken.GenerateToken(usuario, hostName, aplicationID);
                return Ok(usuario);
            }
            return Unauthorized();
        }

        
       

    }
}