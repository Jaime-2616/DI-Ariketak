using System.Windows;

namespace _4_Ariketa
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Password;

            if (usuario == "Admin" && password == "1234")
            {
                lblMensaje.Content = "Bienvenido al Sistema, " + usuario;
            }
            else
            {
                lblMensaje.Content = "Identifikatu gabeko erabiltzailea";
            }
        }

        private void Button_Limpiar(object sender, RoutedEventArgs e)
        {
            txtUsuario.Clear();
            txtPassword.Clear();
            lblMensaje.Content = "";
        }

        private void Button_Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
