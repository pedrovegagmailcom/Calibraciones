using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using ApiWebNetCore.Modelo;
using ApiWebNetCore.Repositorio;
using AutoMapper;

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

        public async Task<UsuarioSesionDTO> BuscarPorPassworAsync(string codigoUsuario, string password)
        {
            
            var usuario = await _seguridadRepositorio.BuscarPorPassworAsync(codigoUsuario, password);
            if (usuario != null)
            {
                var usuarioSesion = _mapper.Map<UsuarioDTO, UsuarioSesionDTO>(usuario);
                return usuarioSesion;
                
            }
            return null;
        }

        [HttpGet()]
        public async Task<IActionResult> Crear(string codigoUsuario, string password, string hostName, Guid aplicationID)
        {
            if (string.IsNullOrEmpty(codigoUsuario) || string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }
            var usuario = await BuscarPorPassworAsync(MetodosEncriptacion.Desencriptar(codigoUsuario), MetodosEncriptacion.Desencriptar(password));
            if (usuario != null)
            {
                usuario.Token = UtilidadesToken.GenerateToken(usuario, hostName, aplicationID);
                return Ok(usuario);
            }
            return Unauthorized();
        }

        
        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> ModificarPassword(string codigoUsuario, string nuevoPassword, string passwordActual)
        {
            if (string.IsNullOrEmpty(codigoUsuario) ||
                string.IsNullOrEmpty(nuevoPassword) ||
                string.IsNullOrEmpty(passwordActual))
            {
                return BadRequest();
            }
            var usuario = await _usuariosBLL.BuscarPorPassworAsync(MetodosEncriptacion.Desencriptar(codigoUsuario), MetodosEncriptacion.Desencriptar(passwordActual));
            if (usuario != null)
            {
                if (await _usuariosBLL.ModificarPasswordAsync(usuario.PkUsuario, MetodosEncriptacion.Desencriptar(nuevoPassword)))
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(409);
                }
            }
            return Unauthorized();
        }

    }
}