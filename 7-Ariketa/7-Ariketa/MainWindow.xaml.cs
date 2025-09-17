using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora
{
    public partial class MainWindow : Window
    {
        double valor1 = 0;
        double valor2 = 0;
        string operacion = "";
        bool nuevoNumero = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Numero_Click(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            if (txtDisplay.Text == "0" || nuevoNumero)
            {
                txtDisplay.Text = "";
                nuevoNumero = false;
            }
            txtDisplay.Text += boton.Content.ToString();
        }

        private void Operacion_Click(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            valor1 = double.Parse(txtDisplay.Text);
            operacion = boton.Content.ToString();
            nuevoNumero = true;
        }

        private void Igual_Click(object sender, RoutedEventArgs e)
        {
            valor2 = double.Parse(txtDisplay.Text);
            double resultado = 0;

            switch (operacion)
            {
                case "+": resultado = valor1 + valor2; break;
                case "-": resultado = valor1 - valor2; break;
                case "*": resultado = valor1 * valor2; break;
                case "/":
                    if (valor2 != 0)
                        resultado = valor1 / valor2;
                    else
                    {
                        MessageBox.Show("Error: división entre cero");
                        resultado = 0;
                    }
                    break;
            }

            txtDisplay.Text = resultado.ToString();
            nuevoNumero = true;
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            valor1 = valor2 = 0;
            operacion = "";
        }

        private void OperacionEspecial_Click(object sender, RoutedEventArgs e)
        {
            valor1 = double.Parse(txtDisplay.Text);
            string op = (sender as Button).Content.ToString();
            double resultado = 0;

            if (op == "%")
                resultado = valor1 / 100;

            txtDisplay.Text = resultado.ToString();
            nuevoNumero = true;
        }
    }
}
