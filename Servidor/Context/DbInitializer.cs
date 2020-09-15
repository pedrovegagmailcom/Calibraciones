using ApiWebNetCore.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Context
{
    public class DbInitializer
    {
        public static void Initialize(MainContext context)
        {

            try
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            // Look for any students.
            if (context.Clientes.Any())
            {
                return;   // DB has been seeded
            }

            var clientes = new Cliente[]
            {
                new Cliente{Nombre="Ubis",Pais="España"},
                new Cliente{Nombre="Ikusi",Pais="España"},
                new Cliente{Nombre="AMC",Pais="Alemania"},

            };
            foreach (Cliente s in clientes)
            {
                context.Clientes.Add(s);
            }
            context.SaveChanges();

            var maquinas = new Maquina[]
            {
                new Maquina{Nombre="HTE 5KS"},
                new Maquina{Nombre="HTE 10KS"},
                new Maquina{Nombre="Validator"},
                new Maquina{Nombre="Micrometro"},
            };
            foreach (Maquina c in maquinas)
            {
                context.Maquinas.Add(c);
            }
            context.SaveChanges();

            var clienteId = context.Clientes.First().ClienteID;
            var maquinaId = context.Maquinas.First().MaquinaID;

            var clienteMaquina = new MaquinaCliente
            {
                ClienteID = clienteId,
                MaquinaID = maquinaId
            };

            context.Add(clienteMaquina);

            var usuario = new Usuario()
            {
                Nombre = "PVega"

            };
            context.Add(usuario);

            context.SaveChanges();
        }
    }
}
