using ClienteApiWebNetCore.Modules.ModuleName.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ClienteApiWebNetCore.Modules.ModuleName.Views
{
    
    public partial class CertificadosView : UserControl
    {
        CertificadosViewModel ViewModel
        {
            get
            {
                return (CertificadosViewModel)DataContext;
            }
        }
        public CertificadosView()
        {
            InitializeComponent();
            
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ((CertificadosViewModel)DataContext).IniciarDatosControl();
        }
    }
}
