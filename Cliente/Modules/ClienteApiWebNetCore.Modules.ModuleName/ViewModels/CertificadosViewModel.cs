using ClienteApiWebNetCore.Core;
using ClienteApiWebNetCore.Core.Mvvm;
using ClienteApiWebNetCore.Dtos;
using ClienteApiWebNetCore.Dtos.Seguridad;
using ClienteApiWebNetCore.Services.Interfaces;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;

namespace ClienteApiWebNetCore.Modules.ModuleName.ViewModels
{
    public class CertificadosViewModel : RegionViewModelBase
    {
        
        private IRegionManager _regionManager;
        private IServicioCertificados _servicioCertificados;


        private CertificadoDTO _certificadoSeleccionado;
        public CertificadoDTO CertificadoSeleccionado
        {
            get { return _certificadoSeleccionado; }
            set
            {
                SetProperty(ref _certificadoSeleccionado, value);
                var parameters = new NavigationParameters();
                parameters.Add("certificado", _certificadoSeleccionado);
                _regionManager.RequestNavigate(RegionNames.ContentRegion, "CertificadoView", parameters);
            }
        }

        private List<CertificadoDTO> _listaCertificados;
        public List<CertificadoDTO> ListaCertificados
        {
            get { return _listaCertificados; }
            set { SetProperty(ref _listaCertificados, value); }
        }



        public event EventHandler<CertificadoDTO> ProcessCompleted;



        public CertificadosViewModel(IRegionManager regionManager, IServicioCertificados servicioCertificados, IEventAggregator eventAggregator) :
            base(regionManager)
        {
           
            _regionManager = regionManager;
            _servicioCertificados = servicioCertificados;
            
        }



        public async void IniciarDatosControl()
        {

            ListaCertificados = await _servicioCertificados.BuscarCertificadosAsync();
            
        }


    }
}
