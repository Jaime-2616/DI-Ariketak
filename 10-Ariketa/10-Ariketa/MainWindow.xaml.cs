using System;
using System.Windows;
using System.Windows.Controls;

namespace _10_Ariketa
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cboImagenes.SelectedIndex = -1;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                img1.Visibility = chkImg1.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
                img2.Visibility = chkImg2.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
                img3.Visibility = chkImg3.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar imágenes: {ex.Message}");
            }
        }

        private void cboImagenes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                img4.Visibility = Visibility.Collapsed;
                img5.Visibility = Visibility.Collapsed;
                img6.Visibility = Visibility.Collapsed;

                if (cboImagenes.SelectedIndex >= 0 && cboImagenes.SelectedIndex < 3)
                {
                    switch (cboImagenes.SelectedIndex)
                    {
                        case 0: img4.Visibility = Visibility.Visible; break;
                        case 1: img5.Visibility = Visibility.Visible; break;
                        case 2: img6.Visibility = Visibility.Visible; break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar imagen: {ex.Message}");
            }
        }
        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}