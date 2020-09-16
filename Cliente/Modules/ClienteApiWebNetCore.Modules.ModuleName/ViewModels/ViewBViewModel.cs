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
    public class ViewBViewModel : RegionViewModelBase
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


      

        public ViewBViewModel(IRegionManager regionManager,IServicioSesion servicioSesion) :
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
