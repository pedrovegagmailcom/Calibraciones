using ClienteApiWebNetCore.Dtos.Seguridad;
using ClienteApiWebNetCore.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows;

namespace ClienteApiWebNetCore.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private string _message;
        private IServicioUsuarios _servicioUsuarios;
        private IServicioSesion _servicioSesion;
        private Window _window;

        private List<UsuarioSesionDTO> _listaUsuarios = new List<UsuarioSesionDTO>();

        public List<UsuarioSesionDTO> ListaUsuarios
        {
            get { return _listaUsuarios; }
            set { SetProperty(ref _listaUsuarios, value); }
        }

        private UsuarioSesionDTO _usuarioSeleccionado;
        public UsuarioSesionDTO UsuarioSeleccionado
        {
            get { return _usuarioSeleccionado; }
            set { SetProperty(ref _usuarioSeleccionado, value); }
        }
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }


        public DelegateCommand LoginCommand { get; private set; }
       
        public LoginViewModel(IServicioUsuarios servicioUsuarios, IServicioSesion servicioSesion) 
        {

            _servicioUsuarios = servicioUsuarios;
            _servicioSesion = servicioSesion;
            LoginCommand = new DelegateCommand(EjecutarLogin);
        }

        private async void EjecutarLogin()
        {
            var resultadoInicioSesion = await _servicioSesion.IniciarSesion(UsuarioSeleccionado.CodigoUsuario);

            if (resultadoInicioSesion)
            {
                Message = "Inicio de sesión correcto : " + _servicioSesion.UsuarioSesion.Nombre;
                _window.Close();
            }
            else
            {
                Message = "Inicio de sesión incorrecto";
            }
        }

        public async void IniciarDatosControl(Window window)
        {
            _window = window;
            ListaUsuarios = await _servicioUsuarios.BuscarUsuariosAsync();
            ListaUsuarios.Add(new UsuarioSesionDTO { CodigoUsuario = "NoUser" });
        }
    }
}
