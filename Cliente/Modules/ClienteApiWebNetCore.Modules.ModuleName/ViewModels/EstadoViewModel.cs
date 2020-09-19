using ClienteApiWebNetCore.Core.Mvvm;
using ClienteApiWebNetCore.Services.Interfaces;
using Prism.Regions;

namespace ClienteApiWebNetCore.Modules.ModuleName.ViewModels
{
    public class EstadoViewModel : RegionViewModelBase
    {
        private IServicioSesion _servicioSesion;
        private string _estadoServidor;
        public string EstadoServidor { get { return _estadoServidor; } set { SetProperty(ref _estadoServidor, value); }}



        public EstadoViewModel(IRegionManager regionManager, IServicioSesion servicioSesion) : base(regionManager)
        {
            _servicioSesion = servicioSesion;

            
            _servicioSesion.FalloComunicacionServidor += FalloComunicacionServidor;
            _servicioSesion.ComunicacionServidorRecuperada += ComunicacionServidorRecuperada;
        }

        private void ComunicacionServidorRecuperada()
        {
            EstadoServidor = "Online";
        }

        private void FalloComunicacionServidor()
        {
            EstadoServidor = "Offline";
        }

        
    }
}
