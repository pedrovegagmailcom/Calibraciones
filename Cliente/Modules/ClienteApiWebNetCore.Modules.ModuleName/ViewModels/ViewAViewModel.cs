using ClienteApiWebNetCore.Core;
using ClienteApiWebNetCore.Core.Mvvm;
using ClienteApiWebNetCore.Modules.ModuleName.Views;
using ClienteApiWebNetCore.Services.Interfaces;
using ClienteApiWebNetCore.Services.Interfaces.DTOS;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private string _message;
        private IServicioUsuarios _servicioUsuarios;
        private IServicioSesion _servicioSesion;
        private IRegionManager _regionManager;

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


        public ViewAViewModel(IRegionManager regionManager, IServicioUsuarios servicioUsuarios, IServicioSesion servicioSesion) :
            base(regionManager)
        {

            _servicioUsuarios = servicioUsuarios;
            _servicioSesion = servicioSesion;
            _regionManager = regionManager;
            LoginCommand = new DelegateCommand(EjecutarLogin);
        }

        private async void EjecutarLogin()
        {
            var resultadoInicioSesion = await _servicioSesion.IniciarSesion(UsuarioSeleccionado.CodigoUsuario);

            if (resultadoInicioSesion)
            {
                Message = "Inicio de sesión correcto : " + _servicioSesion.UsuarioSesion.Nombre;
                _regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewB");
            }
            else
            {
                Message = "Inicio de sesión incorrecto";
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        public async void IniciarDatosControl()
        {
            ListaUsuarios = await _servicioUsuarios.BuscarUsuariosAsync();
        }
    }
}
