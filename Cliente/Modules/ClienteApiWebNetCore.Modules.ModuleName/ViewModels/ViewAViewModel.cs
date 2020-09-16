using ClienteApiWebNetCore.Core.Mvvm;
using ClienteApiWebNetCore.Services.Interfaces;
using ClienteApiWebNetCore.Services.Interfaces.DTOS;
using Prism.Regions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private string _message;
        private IServicioUsuarios _servicioUsuarios;

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

        public ViewAViewModel(IRegionManager regionManager, IServicioUsuarios servicioUsuarios) :
            base(regionManager)
        {

            _servicioUsuarios = servicioUsuarios;
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
