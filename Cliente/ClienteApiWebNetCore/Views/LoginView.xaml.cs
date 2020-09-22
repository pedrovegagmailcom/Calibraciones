using ClienteApiWebNetCore.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ClienteApiWebNetCore.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public Window window;
        LoginViewModel ViewModel
        {
            get
            {
                return (LoginViewModel)DataContext;
            }
        }
        public LoginView()
        {
            InitializeComponent();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            window = Window.GetWindow(this.Parent);
            ((LoginViewModel)DataContext).IniciarDatosControl(window);

            

        }
    }
}
