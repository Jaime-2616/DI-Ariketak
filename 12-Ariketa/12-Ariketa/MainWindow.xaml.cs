using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace _12_Ariketa
{
    public partial class MainWindow : Window
    {
        private const double PRECIO_DESAYUNO = 3.0;
        private const double PRECIO_COMIDA = 9.0;
        private const double PRECIO_CENA = 15.5;
        private const double PRECIO_KM = 0.25;
        private const double PRECIO_DIA_VIAJE = 18.0;
        private const double PRECIO_DIA_TRABAJO = 42.0;

        public MainWindow()
        {
            InitializeComponent();


            txtKm.TextChanged += OnTextChanged;
            txtDiasViaje.TextChanged += OnTextChanged;
            txtDiasTrabajo.TextChanged += OnTextChanged;
            chkDesayuno.Checked += OnCheckChanged;
            chkDesayuno.Unchecked += OnCheckChanged;
            chkComida.Checked += OnCheckChanged;
            chkComida.Unchecked += OnCheckChanged;
            chkCena.Checked += OnCheckChanged;
            chkCena.Unchecked += OnCheckChanged;
        }


        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularTotal();
        }

        private void OnCheckChanged(object sender, RoutedEventArgs e)
        {
            CalcularTotal();
        }

        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            CalcularTotal();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            chkDesayuno.IsChecked = true;
            chkComida.IsChecked = true;
            chkCena.IsChecked = true;
            txtKm.Text = "0";
            txtDiasViaje.Text = "0";
            txtDiasTrabajo.Text = "0";
            txtTotal.Text = "0 €";
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CalcularTotal()
        {
            try
            {
                double total = 0;

                if (chkDesayuno.IsChecked == true)
                    total += PRECIO_DESAYUNO;

                if (chkComida.IsChecked == true)
                    total += PRECIO_COMIDA;

                if (chkCena.IsChecked == true)
                    total += PRECIO_CENA;

                if (double.TryParse(txtKm.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double km))
                    total += km * PRECIO_KM;

                if (double.TryParse(txtDiasViaje.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double diasViaje))
                    total += diasViaje * PRECIO_DIA_VIAJE;

                if (double.TryParse(txtDiasTrabajo.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double diasTrabajo))
                    total += diasTrabajo * PRECIO_DIA_TRABAJO;

                txtTotal.Text = $"{total.ToString("F2")} €";
            }
            catch (Exception ex)
            {
                txtTotal.Text = "0 €";
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != '.' && c != ',')
                {
                    e.Handled = true;
                    return;
                }
            }
            e.Handled = false;
        }
    }


}