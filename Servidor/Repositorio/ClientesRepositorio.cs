using ApiWebNetCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Repositorio
{
    public class ClientesRepositorio : IClientesRepositorio
    {
        private MainContext _contexto;

        public ClientesRepositorio(MainContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<string> GetNombresClientes()
        {
            var clientes = _contexto.Clientes.Select(s => s.Nombre).ToList();
            return clientes;
        }
    }
}
