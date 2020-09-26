using ClienteApiWebNetCore.Core.Mvvm;
using ClienteApiWebNetCore.Dtos;
using ClienteApiWebNetCore.Dtos.Seguridad;
using ClienteApiWebNetCore.Services.Interfaces;
using Prism.Regions;
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
            set { SetProperty(ref _certificadoSeleccionado, value); }
        }

        private List<CertificadoDTO> _listaCertificados;
        public List<CertificadoDTO> ListaCertificados
        {
            get { return _listaCertificados; }
            set { SetProperty(ref _listaCertificados, value); }
        }


        


      

        public CertificadosViewModel(IRegionManager regionManager, IServicioCertificados servicioCertificados) :
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
