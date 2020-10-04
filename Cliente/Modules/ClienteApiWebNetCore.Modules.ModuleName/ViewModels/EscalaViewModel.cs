using ClienteApiWebNetCore.Dtos;
using ClienteApiWebNetCore.Services.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteApiWebNetCore.Modules.ModuleName.ViewModels
{
    class EscalaViewModel : BindableBase
    {
        private IServicioCertificados _servicioCertificados;


        private EscalaDTO _escalaDTO;
        public EscalaDTO EscalaDTO
        {
            get { return _escalaDTO; }
            set { SetProperty(ref _escalaDTO, value); }
        }

        private List<MedicionDTO> _listaMediciones;

        
        public List<MedicionDTO> ListaMediciones
        {
            get { return _listaMediciones; }
            set { SetProperty(ref _listaMediciones, value); }
        }


        public EscalaViewModel(EscalaDTO escalaDTO)
        {
            _escalaDTO = escalaDTO;
            ListaMediciones = _escalaDTO.Mediciones;
        }


        public async void IniciarDatosControl()
        {


        }
    }
}
