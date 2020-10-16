using ClienteApiWebNetCore.Core.Mvvm;
using ClienteApiWebNetCore.Dtos;
using ClienteApiWebNetCore.Dtos.Seguridad;
using ClienteApiWebNetCore.Services.Interfaces;
using Prism.Regions;

namespace ClienteApiWebNetCore.Modules.ModuleName.ViewModels
{
    public class CertificadoViewModel : RegionViewModelBase
    {
        
        private IServicioCertificados _servicioCertificados;
        private IRegionManager _regionManager;



        private CertificadoDTO _certificadoSeleccionado;
        public CertificadoDTO CertificadoSeleccionado
        {
            get { return _certificadoSeleccionado; }
            set
            {
                SetProperty(ref _certificadoSeleccionado, value);
                
            }
        }


        public CertificadoViewModel(IRegionManager regionManager, IServicioCertificados servicioCertificados) :
            base(regionManager)
        {


            _servicioCertificados = servicioCertificados;
            _regionManager = regionManager;
            
        }



        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            CertificadoSeleccionado = navigationContext.Parameters["certificado"] as CertificadoDTO;
            //CertificadoSeleccionado = await _servicioCertificados.BuscarCertificadoAsync(certificadoDTO.NumeroCertificado);

        }


    }
}
