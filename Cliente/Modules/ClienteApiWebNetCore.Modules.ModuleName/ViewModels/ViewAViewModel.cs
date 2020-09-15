using ClienteApiWebNetCore.Core.Mvvm;
using ClienteApiWebNetCore.Services.Interfaces;
using Prism.Regions;
using System.Threading.Tasks;

namespace ClienteApiWebNetCore.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private string _message;
        private IServicioClientes _messageService;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel(IRegionManager regionManager, IServicioClientes messageService) :
            base(regionManager)
        {

            _messageService = messageService;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        public async void IniciarDatosControl()
        {
            Message = await _messageService.GetMessage();
        }
    }
}
