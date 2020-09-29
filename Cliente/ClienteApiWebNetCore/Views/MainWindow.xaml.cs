using ClienteApiWebNetCore.Modules.ModuleName.Views;
using System.Windows;

namespace ClienteApiWebNetCore.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void Window_Initialized(object sender, System.EventArgs e)
        {
            var login = new LoginView();
            Window window = new Window
            {
                Title = "Login",
                Content = login,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                SizeToContent = SizeToContent.WidthAndHeight
            };
            window.ShowDialog();

        }
    }
}
