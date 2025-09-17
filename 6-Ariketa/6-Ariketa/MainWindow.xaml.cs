using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IntroTekla
{
    public partial class MainWindow : Window
    {
        TextBox[] cajas;

        public MainWindow()
        {
            InitializeComponent();
            cajas = new TextBox[] { txt1, txt2, txt3 };
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox actual = sender as TextBox;
                int index = System.Array.IndexOf(cajas, actual);
                int siguiente = (index + 1) % cajas.Length;

                string texto = actual.Text;
                actual.Clear();
                cajas[siguiente].Text = texto;
                cajas[siguiente].Focus();
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            foreach (var caja in cajas)
                caja.Clear();
            txt1.Focus();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
