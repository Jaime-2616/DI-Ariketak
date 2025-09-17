using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace EstilosTiposLetra
{
    public partial class MainWindow : Window
    {
        private bool isBold = false;
        private bool isItalic = false;
        private bool isUnderline = false;
        private bool isStrikethrough = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnComicSans_Click(object sender, RoutedEventArgs e)
        {
            txtTitulo.FontFamily = new FontFamily("Comic Sans MS");
        }

        private void BtnCourier_Click(object sender, RoutedEventArgs e)
        {
            txtTitulo.FontFamily = new FontFamily("Courier New");
        }

        private void BtnNegrita_Click(object sender, RoutedEventArgs e)
        {
            isBold = !isBold;
            txtTitulo.FontWeight = isBold ? FontWeights.Bold : FontWeights.Normal;
        }

        private void BtnCursiva_Click(object sender, RoutedEventArgs e)
        {
            isItalic = !isItalic;
            txtTitulo.FontStyle = isItalic ? FontStyles.Italic : FontStyles.Normal;
        }

        private void BtnSubrayado_Click(object sender, RoutedEventArgs e)
        {
            isUnderline = !isUnderline;
            txtTitulo.TextDecorations = isUnderline ? TextDecorations.Underline : null;
        }

        private void BtnTachado_Click(object sender, RoutedEventArgs e)
        {
            isStrikethrough = !isStrikethrough;
            txtTitulo.TextDecorations = isStrikethrough ? TextDecorations.Strikethrough : null;
        }

        private void BtnAumentar_Click(object sender, RoutedEventArgs e)
        {
            txtTitulo.FontSize += 2;
        }

        private void BtnDisminuir_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitulo.FontSize > 8)
                txtTitulo.FontSize -= 2;
        }

        private void BtnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            string seleccionado = txtEditor.SelectedText;
            int longitud = txtEditor.Text.Length;

            if (string.IsNullOrEmpty(seleccionado))
                lblInfo.Content = $"El texto tiene {longitud} caracteres, y no hay texto seleccionado.";
            else
                lblInfo.Content = $"El texto tiene {longitud} caracteres, y el texto seleccionado es: {seleccionado}";
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
