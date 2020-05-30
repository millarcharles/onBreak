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
using onBreak.ModCliente;
using onBreak.ModContrato;

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

       

        private void navToClienteAd_Click(object sender, RoutedEventArgs e)
        {

            ClienteAdmin _clienteAdmin = new ClienteAdmin();

            _clienteAdmin.Owner= this;
            _clienteAdmin.ShowDialog();

        }

        private void navToClienteLi_Click(object sender, RoutedEventArgs e)
        {
            ClienteLista _clienteLista = new ClienteLista();
            _clienteLista.Owner = this;
            _clienteLista.ShowDialog();
        }
    }
    }

