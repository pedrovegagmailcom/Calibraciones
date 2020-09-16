using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Core
{
    public class ExcepticionNoAutorizado : Exception
    {

    }

    public class ServicioServidor : IServicioServidor
    {

        HttpClient _client = new HttpClient();
        const int NumeroIntentosConexion = 1;

        public ServicioServidor()
        {

            _client.BaseAddress = new Uri("https://localhost:44361/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<TDto> GetAsync<TDto>(string uri)
        {
            try
            {
                return await GetAsyncInterno<TDto>(uri);
            }
            catch (ExcepticionNoAutorizado ex)
            {
            

                throw ex;
            }

        }

        public async Task<string> GetAsync(string uri)
        {
            int intentos_conexion = 0;
            HttpResponseMessage response = null;
            do
            {
                try
                {
                    response = await _client.GetAsync(uri);
                }
                catch (Exception)
                {
                    intentos_conexion++;
                }

                if (intentos_conexion >= NumeroIntentosConexion)
                {
                    // generar evento
                    //_servicioSesion.LanzarFalloComunicacionServidor();
                }
            } while (response == null);

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                return resultado;
                //return JsonConvert.DeserializeObject<TDto>(resultado);
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

        internal async Task<TDto> GetAsyncInterno<TDto>(string uri)
        {
            int intentos_conexion = 0;
            HttpResponseMessage response = null;
            do
            {
                try
                {
                    response = await _client.GetAsync(uri);
                }
                catch (Exception ex)
                {
                    intentos_conexion++;
                }

                if (intentos_conexion >= NumeroIntentosConexion)
                {
                    // generar evento
                    //_servicioSesion.LanzarFalloComunicacionServidor();
                }
            } while (response == null);

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
    }
}
