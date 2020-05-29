using onBreak_DAL;
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
using System.Linq.Expressions;

namespace onBreak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clienteViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clienteViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // clienteViewSource.Source = [generic data source]
        }

        private void LimpiarCampos()
        {
            rutClienteTextBox.Text = string.Empty;
            razonSocialTextBox.Text = string.Empty;
            nombreContactoTextBox.Text = string.Empty;
            mailContactoTextBox.Text = string.Empty;
            telefonoTextBox.Text = string.Empty;
            idActividadEmpresaTextBox.Text = string.Empty;
            idTipoEmpresaTextBox.Text = string.Empty;
            direccionTextBox.Text = string.Empty;
        }

     

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            ServiceCliente _servicio = new ServiceCliente();
            Cliente _cliente = new Cliente();


            _cliente.RutCliente = rutClienteTextBox.Text;
            _cliente.RazonSocial = razonSocialTextBox.Text;
            _cliente.NombreContacto = nombreContactoTextBox.Text;
            _cliente.MailContacto = mailContactoTextBox.Text;
            _cliente.Telefono = telefonoTextBox.Text;
            _cliente.IdActividadEmpresa = int.Parse(idActividadEmpresaTextBox.Text);
            _cliente.IdTipoEmpresa = int.Parse(idTipoEmpresaTextBox.Text);
            _cliente.Direccion = direccionTextBox.Text;
            try
            {
                _servicio.addEntity(_cliente);
                MessageBox.Show("Cliente Agregado con exito");
                LimpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());

            }
        }
    }
    }

