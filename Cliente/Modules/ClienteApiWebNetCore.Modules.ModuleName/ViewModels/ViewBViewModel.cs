using ClienteApiWebNetCore.Core.Mvvm;
using ClienteApiWebNetCore.Dtos.Seguridad;
using ClienteApiWebNetCore.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Documents;

namespace ClienteApiWebNetCore.Modules.ModuleName.ViewModels
{
    
    public class ViewBViewModel : RegionViewModelBase
    {

        public class PuntoCalibracion
        {
            public int MedidaPatron { get; set; }
            public int MedidaEquipo { get; set; }
        }

        private string _message;
        private IServicioUsuarios _servicioUsuarios;
        private IServicioSesion _servicioSesion;
        private IRegionManager _regionManager;

        private List<PuntoCalibracion> _listaMedidas = new List<PuntoCalibracion>();

        public List<PuntoCalibracion> ListaMedidas
        {
            get { return _listaMedidas; }
            set { SetProperty(ref _listaMedidas, value); }
        }

        public DelegateCommand OkCommand { get; private set; }

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

        private void Ok()
        {
            Debug.WriteLine("hola");
        }
      

        public ViewBViewModel(IRegionManager regionManager,IServicioSesion servicioSesion) :
            base(regionManager)
        {

           
            _servicioSesion = servicioSesion;
            _regionManager = regionManager;

            OkCommand = new DelegateCommand(Ok);
            
        }

        

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        
    }
}
