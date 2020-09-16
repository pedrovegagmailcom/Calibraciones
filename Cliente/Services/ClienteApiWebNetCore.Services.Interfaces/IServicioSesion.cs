using ClienteApiWebNetCore.Services.Interfaces.DTOS;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Services.Interfaces
{
    public delegate void AutenticacionFallidaHandler();
    public delegate void FalloComunicacionServidorHandler();
    public delegate void AutenticacionCorrectaHandler(UsuarioSesionDTO usuarioAutenticado);

    public interface IServicioSesion
    {
        bool SesionIniciada { get; }
        UsuarioSesionDTO UsuarioSesion { get; }

        event AutenticacionCorrectaHandler AutenticadoCorrectamente;
        event AutenticacionFallidaHandler AutenticadoFallido;
        event FalloComunicacionServidorHandler FalloComunicacionServidor;

        Task<bool> IniciarSesion(string codigoUsuario);
        Task<bool> RealizarAutenticacion();
        void LanzarFalloComunicacionServidor();
        Guid AplicationID { get; }
        Task<bool> ConexionServidorOk();

    }
}
