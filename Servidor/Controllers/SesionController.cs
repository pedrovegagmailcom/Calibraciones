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
using System.Collections.Generic;

namespace GL2017.API.Controladores.Seguridad
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : Controller
    {
        ISeguridadRepositorio _seguridadRepositorio;
        private readonly IMapper _mapper;

        public SesionController(ISeguridadRepositorio seguridadRepositorio, IMapper mapper)
        {
            _seguridadRepositorio = seguridadRepositorio;
            _mapper = mapper;
        }

        public async Task<UsuarioSesionDTO> BuscarUsuarioAsync(string codigoUsuario)
        {
            
            var usuarioSesionDTO = await _seguridadRepositorio.BuscarAsync(codigoUsuario);
            if (usuarioSesionDTO != null)
            {
                return usuarioSesionDTO;
            }
            return null;
        }

        [HttpGet]
        public async Task<List<UsuarioSesionDTO>> BuscarUsuariosAsync()
        {

            var usuariosDTO = await _seguridadRepositorio.BuscarTodosAsync();
            if (usuariosDTO != null)
            {
                
                return usuariosDTO;

            }
            return null;
        }



       
        public async Task<IActionResult> CrearSesionstring(string codigoUsuario, string hostName, Guid aplicationID)
        {
            if (codigoUsuario == null)
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