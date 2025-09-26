using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _9_Ariketa
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAñadir_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxAmigoNuevo.Text))
            {
                MessageBox.Show("Introduzca datos para poder añadirlos.", "Error Añadir", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ListBoxAmigos.Items.Add(TextBoxAmigoNuevo.Text.Trim());
            TextBoxAmigoNuevo.Clear();
        }

        private void ButtonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAmigos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione datos para poder eliminarlos.", "Error Eliminar", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var itemsToRemove = new System.Collections.ArrayList(ListBoxAmigos.SelectedItems);
            foreach (var item in itemsToRemove)
            {
                ListBoxAmigos.Items.Remove(item);
            }

            TextBoxAmigoSeleccionado.Clear();
        }

        private void ButtonBorrarLista_Click(object sender, RoutedEventArgs e)
        {
            ListBoxAmigos.Items.Clear();
            TextBoxAmigoSeleccionado.Clear();
        }

        private void ButtonSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListBoxAmigos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBoxAmigos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBoxAmigos.SelectedItem != null)
            {
                TextBoxAmigoSeleccionado.Text = ListBoxAmigos.SelectedItem.ToString();
            }
        }
    }
}