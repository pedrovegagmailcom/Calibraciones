﻿using System;
using System.Threading.Tasks;
using ApiWebNetCore.DTOS;
using ApiWebNetCore.Repositorio;
using Microsoft.AspNetCore.Mvc;


namespace ApiWebNetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CertificadosController : ControllerBase
    {
        private ICertificadosRepositorio _certificadosRepositorio;

        public CertificadosController(ICertificadosRepositorio certificadosRepositorio)
        {
            _certificadosRepositorio = certificadosRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarCertificado([FromBody] CertificadoDTO certificadoDTO)
        {
            if (certificadoDTO == null)
            {
                return BadRequest();
            }

            var certificadoID = await _certificadosRepositorio.AgregarCertificado(certificadoDTO);
            if (certificadoID == Guid.Empty)
            {
                return StatusCode(409);
            }
           
            return Ok(certificadoID);
        }

        
    }
}
