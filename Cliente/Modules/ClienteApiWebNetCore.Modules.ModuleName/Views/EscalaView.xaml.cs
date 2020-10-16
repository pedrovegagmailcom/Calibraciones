using ClienteApiWebNetCore.Dtos;
using ClienteApiWebNetCore.Modules.ModuleName.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ClienteApiWebNetCore.Modules.ModuleName.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class EscalaView : UserControl
    {
        EscalaViewModel ViewModel
        {
            get
            {
                return (EscalaViewModel)DataContext;
            }
        }

        private EscalaDTO _escalaDTO;

        public EscalaView(EscalaDTO escala)
        {
            InitializeComponent();
            _escalaDTO = escala;
            ViewModel.EscalaDTO = escala;
            ViewModel.ListaMediciones = escala.Mediciones;
        }


        
    }
}
