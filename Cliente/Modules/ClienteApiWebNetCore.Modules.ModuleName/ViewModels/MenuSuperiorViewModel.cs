using ClienteApiWebNetCore.Core.Mvvm;
using ClienteApiWebNetCore.Dtos.Seguridad;
using ClienteApiWebNetCore.Modules.ModuleName.Views;
using ClienteApiWebNetCore.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using System.Windows;

namespace ClienteApiWebNetCore.Modules.ModuleName.ViewModels
{
    public class MenuSuperiorViewModel : RegionViewModelBase
    {
        private string _message;
        private IServicioUsuarios _servicioUsuarios;
        private IServicioSesion _servicioSesion;
        private IRegionManager _regionManager;

        

        private UsuarioSesionDTO _usuarioSeleccionado;
        public UsuarioSesionDTO UsuarioSeleccionado
        {
            get { return _usuarioSeleccionado; }
            set { SetProperty(ref _usuarioSeleccionado, value); }
        }
        public string Message
        {
            get { return _servicioSesion.UsuarioSesion.Nombre; }
            
        }

        public DelegateCommand NuevoCertificadoCommand { get; set; }
      

        public MenuSuperiorViewModel(IRegionManager regionManager,IServicioSesion servicioSesion) :
            base(regionManager)
        {

           
            _servicioSesion = servicioSesion;
            _regionManager = regionManager;

            NuevoCertificadoCommand = new DelegateCommand(NuevoCertificado);


        }


        private void NuevoCertificado()
        {
            var login = new NuevoCertificadoView();
            Window window = new Window
            {
                Title = "Login",
                Content = login,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                SizeToContent = SizeToContent.WidthAndHeight
            };
            window.ShowDialog();
        }


        
    }
}
