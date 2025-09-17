using System.Collections.Generic;
using System.Windows;

namespace _2_Ariketa
{
    public partial class MainWindow : Window
    {
        private List<string> frases = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            txtFrase.Focus();
        }

        
        private void Frase_Click(object sender, RoutedEventArgs e)
        {
            var boton = (System.Windows.Controls.Button)sender;

            if (!string.IsNullOrWhiteSpace(txtFrase.Text))
            {
                frases.Add(txtFrase.Text.Trim());
                txtFrase.Clear();
                txtFrase.Focus();

                boton.IsEnabled = false;

                
                if (boton == btnFrase1) btnFrase2.IsEnabled = true;
                else if (boton == btnFrase2) btnFrase3.IsEnabled = true;
                else if (boton == btnFrase3) btnFrase4.IsEnabled = true;
                else if (boton == btnFrase4) btnFrase5.IsEnabled = true;
                else if (boton == btnFrase5) btnUnir.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Introduce una frase antes de continuar.");
            }
        }

        private void btnUnir_Click(object sender, RoutedEventArgs e)
        {
            string resultado = string.Join(" ", frases);
            MessageBox.Show(resultado, "Frases concatenadas");
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            frases.Clear();
            txtFrase.Clear();

            btnFrase1.IsEnabled = true;
            btnFrase2.IsEnabled = false;
            btnFrase3.IsEnabled = false;
            btnFrase4.IsEnabled = false;
            btnFrase5.IsEnabled = false;
            btnUnir.IsEnabled = false;

            txtFrase.Focus();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
