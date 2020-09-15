﻿using Prism.Ioc;
using ClienteApiWebNetCore.Views;
using System.Windows;
using Prism.Modularity;
using ClienteApiWebNetCore.Modules.ModuleName;
using ClienteApiWebNetCore.Services.Interfaces;
using ClienteApiWebNetCore.Services;
using ClienteApiWebNetCore.Core;

namespace ClienteApiWebNetCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IServicioServidor, ServicioServidor>();
            containerRegistry.RegisterSingleton<IServicioClientes, ServicioClientes>();
            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
