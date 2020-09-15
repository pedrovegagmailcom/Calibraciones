using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebNetCore.Context;
using ApiWebNetCore.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiWebNetCore.Controllers
{
      

    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private IClientesRepositorio _clientesRepositorio;

        public ClientesController(IClientesRepositorio clientesRepositorio)
        {
            _clientesRepositorio = clientesRepositorio;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var clientes = _clientesRepositorio.GetNombresClientes();
            return clientes;
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
