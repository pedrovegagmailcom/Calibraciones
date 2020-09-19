using ClienteApiWebNetCore.Core.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteApiWebNetCore.Modules.ModuleName.ViewModels
{
    public class EstadoViewModel : RegionViewModelBase
    {

        public string EstadoServidor { get { return "Online"; } set { } }
        public EstadoViewModel(IRegionManager regionManager) : base(regionManager)
        {
        }
    }
}
