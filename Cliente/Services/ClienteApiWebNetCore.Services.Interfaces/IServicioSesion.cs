using ClienteApiWebNetCore.Dtos.Seguridad;
using System;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Services.Interfaces
{
    public delegate void AutenticacionFallidaHandler();
    public delegate void FalloComunicacionServidorHandler();
    public delegate void ComunicacionServidorRecuperadaHandler();
    public delegate void AutenticacionCorrectaHandler(UsuarioSesionDTO usuarioAutenticado);

    public interface IServicioSesion
    {
        bool SesionIniciada { get; }
        UsuarioSesionDTO UsuarioSesion { get; }

        event AutenticacionCorrectaHandler AutenticadoCorrectamente;
        event AutenticacionFallidaHandler AutenticadoFallido;
        event FalloComunicacionServidorHandler FalloComunicacionServidor;
        event ComunicacionServidorRecuperadaHandler ComunicacionServidorRecuperada;



        Task<bool> IniciarSesion(string codigoUsuario);
        Task<bool> RealizarAutenticacion();
        Guid AplicationID { get; }
        Task<bool> ConexionServidorOk();

    }
}
