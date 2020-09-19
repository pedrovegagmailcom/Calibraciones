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
            var login = containerProvider.Resolve<LoginView>() as UserControl;
            Window window = new Window
            {
                Title = "Login",
                Content = login,
                SizeToContent = SizeToContent.WidthAndHeight
            };
            window.ShowDialog();

            //_regionManager.RequestNavigate(RegionNames.ContentRegion, "LoginView");
            _regionManager.RequestNavigate(RegionNames.StatusRegion, "EstadoView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginView>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<EstadoView>();
        }
    }
}