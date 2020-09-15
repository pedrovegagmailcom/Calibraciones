using ClienteApiWebNetCore.Core;
using ClienteApiWebNetCore.Core.DTOS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Services
{
    public class ServicioSesion
    {
        private IServicioServidor _servicioServidor;
        HttpClient _clientHttpToken = new HttpClient();
        private string _codigoUsuario;
        public UsuarioSesionDTO UsuarioSesion { get; private set; }

        public Guid AplicationID { get; private set; }



        public ServicioSesion(IServicioServidor servicioServidor)
        {
            _servicioServidor = servicioServidor;
        }


        public async Task<bool> IniciarSesion(string codigoUsuario)
        {
            
            _codigoUsuario = codigoUsuario;

            return await InicioSesion();
        }

        private async Task<bool> InicioSesion()
        {
            var listaParametros = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("codigoUsuario", _codigoUsuario),
                new KeyValuePair<string, string>("hostName", Dns.GetHostName()),
                new KeyValuePair<string, string>("aplicationID", AplicationID.ToString())
            };

            try
            {
                var response = await _clientHttpToken.GetAsync(ConseguirUriConParametros("/api/sesion", listaParametros));

                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadAsStringAsync();
                    UsuarioSesion = JsonConvert.DeserializeObject<UsuarioSesionDTO>(resultado);
                    AgregarTokenClientePermisos();
                    ListaPermisosSesion = await ConseguirPermisosUsuarioAutenticado();
                    LazarAutenticadoCorrectamente();
                    return true;
                }
                else
                {
                    LazarAutenticadoFallido();
                }
            }
            catch (Exception ex)
            {
                //Logear fallo de inicio de sesion
            }

            return false;
        }
    }
}
