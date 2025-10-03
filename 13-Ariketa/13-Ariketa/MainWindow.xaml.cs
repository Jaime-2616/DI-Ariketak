using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace _12_Ariketa
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetupKeyboardShortcuts();
        }

        private void SetupKeyboardShortcuts()
        {
            this.InputBindings.Add(new KeyBinding(
                new RelayCommand(_ => MenuItem_Moztu_Click(null, null)),
                Key.X, ModifierKeys.Control));

            this.InputBindings.Add(new KeyBinding(
                new RelayCommand(_ => MenuItem_Kopiatu_Click(null, null)),
                Key.C, ModifierKeys.Control));

            this.InputBindings.Add(new KeyBinding(
                new RelayCommand(_ => MenuItem_Itsasi_Click(null, null)),
                Key.V, ModifierKeys.Control));

            this.InputBindings.Add(new KeyBinding(
                new RelayCommand(_ => MenuItem_Ezabatu_Click(null, null)),
                Key.Delete, ModifierKeys.None));
        }

        #region Menú ARTXIBATZEA
        private void MenuItem_Gorde_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gordeta!", "Artxibatzeea", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MenuItem_Irten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Menú EDITATU
        private void MenuItem_Moztu_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEditor.SelectedText))
            {
                Clipboard.SetText(txtEditor.SelectedText);
                txtEditor.SelectedText = "";
            }
        }

        private void MenuItem_Kopiatu_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEditor.SelectedText))
            {
                Clipboard.SetText(txtEditor.SelectedText);
            }
        }

        private void MenuItem_Itsasi_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txtEditor.SelectedText = Clipboard.GetText();
            }
        }

        private void MenuItem_Ezabatu_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEditor.SelectedText))
            {
                txtEditor.SelectedText = "";
            }
        }
        #endregion

        #region Menú ITURRIA
        private void CambiarFuente(string nombreFuente)
        {
            FontFamily fuenteActual = txtEditor.FontFamily;
            double tamañoActual = txtEditor.FontSize;
            FontStyle estiloActual = txtEditor.FontStyle;
            FontWeight pesoActual = txtEditor.FontWeight;

            try
            {
                txtEditor.FontFamily = new FontFamily(nombreFuente);
                txtEditor.FontSize = tamañoActual;
                txtEditor.FontStyle = estiloActual;
                txtEditor.FontWeight = pesoActual;
            }
            catch
            {
                MessageBox.Show($"Ezin da '{nombreFuente}' iturria kargatu", "Errorea", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItem_Arial_Click(object sender, RoutedEventArgs e)
        {
            CambiarFuente("Arial");
        }

        private void MenuItem_Courier_Click(object sender, RoutedEventArgs e)
        {
            CambiarFuente("Courier New");
        }

        private void MenuItem_Impact_Click(object sender, RoutedEventArgs e)
        {
            CambiarFuente("Impact");
        }

        private void MenuItem_Symbol_Click(object sender, RoutedEventArgs e)
        {
            CambiarFuente("Symbol");
        }
        #endregion
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;
        public void Execute(object parameter) => _execute(parameter);
    }
}