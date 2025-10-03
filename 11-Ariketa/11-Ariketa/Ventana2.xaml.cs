using System.Windows;

namespace _11_Ariketa
{
    public partial class Ventana2 : Window
    {
        public Ventana2()
        {
            InitializeComponent();

            lblNombre.Text = $"Nombre: {DatosGlobales.Nombre}";
            lblApellido1.Text = $"1º Apellido: {DatosGlobales.Apellido1}";
            lblApellido2.Text = $"2º Apellido: {DatosGlobales.Apellido2}";
            lblDni.Text = $"DNI: {DatosGlobales.Dni}";
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
