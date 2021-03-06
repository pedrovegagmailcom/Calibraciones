﻿using ClienteApiWebNetCore.Core;
using ClienteApiWebNetCore.Dtos.Seguridad;
using ClienteApiWebNetCore.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Services
{
    
    public class ServicioSesion : IServicioSesion
    {
        HttpClient _clientHttpToken = new HttpClient();
        HttpClient _clientHttpPermsos = new HttpClient();
        private string _codigoUsuario;
        public UsuarioSesionDTO UsuarioSesion { get; private set; }

        public Guid AplicationID { get; private set; }

        public event FalloComunicacionServidorHandler FalloComunicacionServidor;
        public event AutenticacionCorrectaHandler AutenticadoCorrectamente;
        public event AutenticacionFallidaHandler AutenticadoFallido;
        public event ComunicacionServidorRecuperadaHandler ComunicacionServidorRecuperada;

        
        public bool SesionIniciada
        {
            get
            {
                return !string.IsNullOrEmpty(_codigoUsuario);
            }
        }


        public ServicioSesion()
        {
            AplicationID = Guid.NewGuid();
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidarCertificado);
            _clientHttpToken.BaseAddress = new Uri("https://localhost:44361/");
            _clientHttpToken.DefaultRequestHeaders.Accept.Clear();
            _clientHttpToken.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _clientHttpPermsos.BaseAddress = new Uri("https://localhost:44361/");
            _clientHttpPermsos.DefaultRequestHeaders.Accept.Clear();
            _clientHttpPermsos.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            UsuarioSesion = new UsuarioSesionDTO();

            Task.Run(() => WatchDogServer());

        }


        public async Task<bool> WatchDogServer()
        {
            while (true)
            {
                var result = await ConexionServidorOk();
                if (result == false)
                {
                    FalloComunicacionServidor?.Invoke();
                }
                else
                {
                    ComunicacionServidorRecuperada?.Invoke();
                }
                Debug.WriteLine(result);
                Thread.Sleep(1000);
            }
        }

        public async Task<bool> RealizarAutenticacion()
        {
            return await InicioSesion();
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
                var response = await _clientHttpToken.GetAsync(ConseguirUriConParametros("/api/sesion/login", listaParametros));

                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadAsStringAsync();
                    UsuarioSesion = JsonConvert.DeserializeObject<UsuarioSesionDTO>(resultado);
                    AgregarTokenClientePermisos();
                    AutenticadoCorrectamente?.Invoke(UsuarioSesion);
                    return true;
                }
                else
                {
                    AutenticadoFallido?.Invoke();
                }
            }
            catch (Exception ex)
            {
                //Logear fallo de inicio de sesion
            }

            return false;
        }


        private void AgregarTokenClientePermisos()
        {
            _clientHttpPermsos.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UsuarioSesion.Token);
        }

        private bool ValidarCertificado(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static string ConseguirUriConParametros(string requestUri, List<KeyValuePair<string, string>> parameters)
        {
            var stringBuilder = new StringBuilder();
            string str = "?";
            for (int index = 0; index < parameters.Count; ++index)
            {
                stringBuilder.Append(str + parameters[index].Key + "=" + parameters[index].Value);
                str = "&";
            }
            return requestUri + stringBuilder.ToString();
        }


        internal async Task<TDto> GetAsyncInterno<TDto>(string uri)
        {
            var response = await _clientHttpPermsos.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TDto>(resultado);
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new ExcepticionNoAutorizado();
                }
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public async Task<bool> ConexionServidorOk()
        {
            try
            {
                await GetAsyncInterno<bool>("api/sesion/estado/");
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
