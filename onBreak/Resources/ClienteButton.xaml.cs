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
using onBreak.ModCliente;
using onBreak.ModContrato;
using onBreak_DAL;

namespace onBreak.Resources
{
    /// <summary>
    /// Interaction logic for ClienteButton.xaml
    /// </summary>
    public partial class ClienteButton : UserControl
    {
        public ClienteButton()
        {
            InitializeComponent();
            
        }

        private void btnAdminClientes_Click(object sender, RoutedEventArgs e)
        {
            ClienteAdmin _clienteAdmin = new ClienteAdmin();
            Window parentWindow = Window.GetWindow(this);

            _clienteAdmin.Owner = parentWindow;
            _clienteAdmin.ShowDialog();
        }

        private void btnListaClientes_Click(object sender, RoutedEventArgs e)
        {
            ClienteLista _clienteLista = new ClienteLista();
            Window parentWindow = Window.GetWindow(this);

            _clienteLista.Owner = parentWindow;
            _clienteLista.ShowDialog();
        }
    }
}
