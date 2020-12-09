using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Actividad_UT4_3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;
        List<Superheroe> superheroes = Superheroe.GetSamples();
        Superheroe superheroe = new Superheroe();

        public MainWindow()
        {
            InitializeComponent();

            datosVerSuperheroe.DataContext = superheroes[i];
            datosFormulario.DataContext = superheroe;

            datosFlechas.DataContext = superheroes.Count;
        }

        private void Menor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (int.Parse(Menor.Text) >= 1 && i >= 1)
            {
                i--;
                Menor.Text = (i + 1) + "";
                datosVerSuperheroe.DataContext = superheroes[i];

            }
        }

        private void Mayor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (i + 1 < superheroes.Count && i <= superheroes.Count)
            {
                i++;
                Menor.Text = (i + 1) + "";
                datosVerSuperheroe.DataContext = superheroes[i];

            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)villanos.IsChecked)
            {
                xmen.IsChecked = false;
                xmen.IsEnabled = false;
                vengadores.IsChecked = false;
                vengadores.IsEnabled = false;
            }
            if ((bool)heroes.IsChecked)
            {
                xmen.IsEnabled = true;
                vengadores.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name.Equals("aceptar"))
            {


                if (nombreHeroe.Text.Equals("") || sourceImagen.Text.Equals(""))
                {
                    MessageBox.Show("El heroe debe tener nombre y imagen", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {

                    superheroes.Add(superheroe);

                    superheroe = new Superheroe();

                    datosFormulario.DataContext = superheroe;

                    Mayor.Text = superheroes.Count.ToString();

                    MessageBox.Show("El heroe se ha añadido", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            if ((sender as Button).Name.Equals("limpiar"))
            {
                nombreHeroe.Text = "";
                sourceImagen.Text = "";
                heroes.IsChecked = false;
                villanos.IsChecked = false;
                xmen.IsChecked = false;
                vengadores.IsChecked = false;
                xmen.IsEnabled = true;
                vengadores.IsEnabled = true;
            }
        }

        private void limpiar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Button_Click(sender, e);
            }
        }
    }


}
