using ClienteApiWebNetCore.Core.Mvvm;
using ClienteApiWebNetCore.Dtos.Seguridad;
using ClienteApiWebNetCore.Services.Interfaces;
using Prism.Regions;

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


      

        public MenuSuperiorViewModel(IRegionManager regionManager,IServicioSesion servicioSesion) :
            base(regionManager)
        {

           
            _servicioSesion = servicioSesion;
            _regionManager = regionManager;
            
        }

        

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        
    }
}
