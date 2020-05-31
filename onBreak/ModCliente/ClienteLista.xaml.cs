using onBreak_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
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
        private readonly ICollectionView _clienteView;
        OnBreakEntities _context = new OnBreakEntities();


        public ClienteLista()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clienteViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clienteViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // clienteViewSource.Source = [generic data source]
            _context.Configuration.ProxyCreationEnabled = false;
            actualizarGrid();
;
        }

        public void actualizarGrid() 
        {
            ServiceCliente _service = new ServiceCliente();
            List<Cliente> l_Clientes= _service.getEntities();
            foreach (Cliente c in l_Clientes)
            {
                ClientesGrid.Items.Add(new Cliente {RutCliente = c.RutCliente,
                                            RazonSocial = c.RazonSocial,
                                            NombreContacto = c.NombreContacto,
                                            MailContacto = c.MailContacto,
                                            Direccion = c.Direccion,
                                            Telefono = c.Telefono,
                                            TipoEmpresa = c.TipoEmpresa,
                                            ActividadEmpresa = c.ActividadEmpresa

                } );

            }



        }

        private void ClientesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEdit.Visibility = Visibility.Visible;

            Cliente _sel = (Cliente)ClientesGrid.SelectedItem;
            Debug.WriteLine(_sel.MailContacto);



            }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ClienteAdmin clienteEdit = new ClienteAdmin((Cliente)ClientesGrid.SelectedItem);
            clienteEdit.Show();

        }
    }
}
