using ClienteApiWebNetCore.Core;
using ClienteApiWebNetCore.Modules.ModuleName.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace ClienteApiWebNetCore.Modules.ModuleName
{
    public class ModuleNameModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleNameModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewB");
            _regionManager.RequestNavigate(RegionNames.StatusRegion, "EstadoView");
            _regionManager.RequestNavigate(RegionNames.MenuSuperior, "MenuSuperiorView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MenuSuperiorView>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<EstadoView>();
            containerRegistry.RegisterForNavigation<SeleccionCertificadoView>();
        }
    }
}