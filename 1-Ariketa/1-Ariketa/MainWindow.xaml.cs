using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _1_Ariketa
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            char input = e.Text[0];
            if (char.IsDigit(input))
            {
                e.Handled = false;
            }
            else if (input == ',' && !textBox.Text.Contains(","))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnOperar_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtA.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double a) &&
                double.TryParse(txtB.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double b) &&
                double.TryParse(txtC.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double c) &&
                double.TryParse(txtD.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double d))
            {
                double result = (a + 2 * b + 3 * c + 4 * d) / 4;
                txtResultado.Text = result.ToString("N2");
            }
            else
            {
                MessageBox.Show("Sartu balio zuzenak.");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtC.Clear();
            txtD.Clear();
            txtResultado.Clear();
            txtA.Focus();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}