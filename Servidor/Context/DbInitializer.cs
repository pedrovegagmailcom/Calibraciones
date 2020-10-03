using ApiWebNetCore.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiWebNetCore.Context
{
    public class DbInitializer
    {
        public static void Initialize(MainContext context)
        {

            try
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            var certificado = context.Certificados.Include(n => n.Escalas).ThenInclude(n=>n.Mediciones).First();

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
                Nombre = "Mikel Barandiaran",
                CodigoUsuario = "Mikel"

            };
            context.Add(usuario);

            usuario = new Usuario()
            {
                Nombre = "Aitor Mendizabal",
                CodigoUsuario = "Aitor"

            };
            context.Add(usuario);

            usuario = new Usuario()
            {
                Nombre = "Pedro Ortega",
                CodigoUsuario = "Pedro"

            };
            context.Add(usuario);

            context.SaveChanges();

            AgregarCertificado(context);

            
        }

        private static void AgregarCertificado(MainContext context)
        {
            var certificado = new Certificado()
            {
                CertificadoId = new Guid(),
                NumeroCertificado = 1,
                NumeroEscalas = 1                
            };

            context.Add(certificado);

            var listaEscalas = new List<Escala>();

            var escala = new Escala()
            {
                Certificado = certificado,
                EscalaId = new Guid(),
                NumeroPuntosCalibracion = 4,
                NumeroRepeticiones = 1,
                Mediciones = new List<Medicion>()
            };

            

            escala.Mediciones.Add(new Medicion() { MedicionId = new Guid(), Escala = escala, NumeroRepeticion = 1, PuntoCalibracion = 1, Mesurando = 0.99, Patron = 10 });
            escala.Mediciones.Add(new Medicion() { MedicionId = new Guid(), Escala = escala, NumeroRepeticion = 1, PuntoCalibracion = 2, Mesurando = 20.3, Patron = 20 });
            escala.Mediciones.Add(new Medicion() { MedicionId = new Guid(), Escala = escala, NumeroRepeticion = 1, PuntoCalibracion = 3, Mesurando = 31,   Patron = 30 });
            escala.Mediciones.Add(new Medicion() { MedicionId = new Guid(), Escala = escala, NumeroRepeticion = 1, PuntoCalibracion = 4, Mesurando = 39.8, Patron = 40 });

            context.Add(escala);

            context.SaveChanges();


            //var puntoCal = new PuntoCalibracion()
            //{
            //    PuntoCalibracionId = new Guid(),
            //    Escala = escala,
            //    Mediciones = new List<Medicion>()
            //};
        }
    }
}
