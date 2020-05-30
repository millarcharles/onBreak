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
using System.Windows.Shapes;

namespace onBreak.ModCliente
{
    /// <summary>
    /// Interaction logic for ClienteLista.xaml
    /// </summary>
    public partial class ClienteLista : Window
    {
        public ClienteLista()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clienteViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clienteViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // clienteViewSource.Source = [generic data source]
        }

        public void actualizarGrid() 
        {
            ServiceCliente _service = new ServiceCliente();
            List<Cliente> l_Clientes= _service.getEntities();
            foreach (Cliente c in l_Clientes)
            {
                ClientesGrid.Items.Add(new {RutCliente = c.RutCliente,
                                            RazonSocial = c.RazonSocial,
                                            NombreContacto = c.NombreContacto,
                                            MailContacto = c.MailContacto,
                                            Direccion = c.Direccion,
                                            Fono = c.Telefono,
                                            Tip = c.TipoEmpresa,
                                            Actividad =c.ActividadEmpresa,

                } );

            }



        }

        private void ClientesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
