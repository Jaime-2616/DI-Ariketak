using System.Windows;

namespace _11_Ariketa
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            DatosGlobales.Nombre = txtNombre.Text;
            DatosGlobales.Apellido1 = txtApellido1.Text;
            DatosGlobales.Apellido2 = txtApellido2.Text;
            DatosGlobales.Dni = txtDni.Text;

            MessageBox.Show("Datos guardados correctamente", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnCargar_Click(object sender, RoutedEventArgs e)
        {
            Ventana2 v2 = new Ventana2();
            v2.Show();
            this.Hide();
        }
    }
}
