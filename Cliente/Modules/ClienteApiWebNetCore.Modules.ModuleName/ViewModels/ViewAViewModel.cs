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
            _listaUsuarios = await _servicioUsuarios.BuscarUsuariosAsync();
        }
    }
}
