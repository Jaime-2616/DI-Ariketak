using System;
using System.Windows;

namespace _8_Ariketa
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) 
        {
            this.Close();
        }

        private void Ejecutar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtAhora.Text = DateTime.Now.ToString();
                txtHoy.Text = DateTime.Today.ToShortDateString();
                txtHoraHoy.Text = DateTime.Now.ToShortTimeString();

                string inputMeses = Microsoft.VisualBasic.Interaction.InputBox(
                    "¿Cuántos meses quieres sumar a la fecha de hoy?",
                    "Suma de Fechas",
                    "0");
                if (!int.TryParse(inputMeses, out int meses))
                    throw new Exception("Número de meses inválido");

                DateTime fechaSuma = DateTime.Today.AddMonths(meses);
                txtSumaFechas.Text = fechaSuma.ToShortDateString();

                string inputF1 = Microsoft.VisualBasic.Interaction.InputBox(
                    "Introduce la primera fecha (dd/MM/yyyy):",
                    "Diferencia de Fechas");
                string inputF2 = Microsoft.VisualBasic.Interaction.InputBox(
                    "Introduce la segunda fecha (dd/MM/yyyy):",
                    "Diferencia de Fechas");

                if (!DateTime.TryParse(inputF1, out DateTime f1) ||
                    !DateTime.TryParse(inputF2, out DateTime f2))
                    throw new Exception("Formato de fecha incorrecto");

                TimeSpan dif = f2 - f1;
                txtDiferencia.Text = Math.Abs(dif.Days).ToString() + " días";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\nVuelve a intentarlo.",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            txtAhora.Clear();
            txtHoy.Clear();
            txtHoraHoy.Clear();
            txtSumaFechas.Clear();
            txtDiferencia.Clear();
        }
    }
}
