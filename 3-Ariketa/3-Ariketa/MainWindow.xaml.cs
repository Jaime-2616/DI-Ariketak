using System.Collections.Generic;
using System.Windows;

namespace _3_Ariketa
{
    public partial class MainWindow : Window
    {
        private List<double> numeros = new List<double>();
        private int contador = 1;

        public MainWindow()
        {
            InitializeComponent();
            txtNumero.Focus();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtNumero.Text, out double num))
            {
                numeros.Add(num);
                txtNumero.Clear();

                if (contador < 4)
                {
                    contador++;
                    lblNumero.Content = $"Numero {contador}";
                    txtNumero.Focus();
                }
                else
                {
                    
                    double num1 = numeros[0];
                    double num2 = numeros[1];
                    double num3 = numeros[2];
                    double num4 = numeros[3];

                    double resultado = (num1 + (num1 * num2) + (num2 * num3) + (num3 * num4)) / 4;

                    txtResultado.Text = resultado.ToString("F2");

                   
                    panelEntrada.Visibility = Visibility.Collapsed;
                    panelResultado.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Tienes que añadir un numero");
                txtNumero.Focus();
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            numeros.Clear();
            contador = 1;
            lblNumero.Content = "Numero 1";
            txtNumero.Clear();

            panelResultado.Visibility = Visibility.Collapsed;
            panelEntrada.Visibility = Visibility.Visible;
            txtNumero.Focus();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
