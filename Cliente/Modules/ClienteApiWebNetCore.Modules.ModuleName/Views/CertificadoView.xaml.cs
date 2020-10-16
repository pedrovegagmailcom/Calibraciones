using ClienteApiWebNetCore.Modules.ModuleName.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ClienteApiWebNetCore.Modules.ModuleName.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class CertificadoView : UserControl
    {
        CertificadoViewModel ViewModel
        {
            get
            {
                return (CertificadoViewModel)DataContext;
            }
        }

        public CertificadoView()
        {
            InitializeComponent();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var cer = ViewModel.CertificadoSeleccionado;
            var escala = cer.Escalas[0];
            TabItem tab_item = new TabItem();

            tab_item.Header = "Escala 1";
            tab_item.Content = new EscalaView(escala);
            tabEscalas.Items.Add(tab_item);
            
        }
    }
}
