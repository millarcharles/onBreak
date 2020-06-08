using MahApps.Metro.Controls;
using onBreak_DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for ClienteAdmin.xaml
    /// </summary>
    public partial class ClienteAdmin : MetroWindow
    {
        public Cliente _clienteEdit;
        ServiceCliente _clientes = new ServiceCliente();



        //ctor con parametro
        public ClienteAdmin(Cliente _clienteinpt)
        {
            InitializeComponent();
            
            
            rutClienteTextBox.Text = _clienteinpt.RutCliente;
            rutClienteTextBox.IsEnabled = false;
            razonSocialTextBox.Text = _clienteinpt.RazonSocial;
            nombreContactoTextBox.Text = _clienteinpt.NombreContacto;
            mailContactoTextBox.Text = _clienteinpt.MailContacto;
            telefonoTextBox.Text = _clienteinpt.Telefono;
            direccionTextBox.Text = _clienteinpt.Direccion;
            _clienteEdit = _clienteinpt;


            _clienteEdit = _clientes.getEntity(_clienteinpt.RutCliente);
            this.DataContext = _clienteEdit;

            TipoEmpresaComboBox.SelectedValue = _clienteEdit.IdTipoEmpresa;
            ActividadComboBox.SelectedValue = _clienteEdit.IdActividadEmpresa;

        }


        private Cliente getClienteForm() {

            Cliente _cliente = new Cliente();


            _cliente.RutCliente = rutClienteTextBox.Text;
            _cliente.RazonSocial = razonSocialTextBox.Text;
            _cliente.NombreContacto = nombreContactoTextBox.Text;
            _cliente.MailContacto = mailContactoTextBox.Text;
            _cliente.Telefono = telefonoTextBox.Text;
            _cliente.IdActividadEmpresa = ((int)ActividadComboBox.SelectedValue);
            _cliente.IdTipoEmpresa = ((int)TipoEmpresaComboBox.SelectedValue);
            _cliente.Direccion = direccionTextBox.Text;

            return _cliente;


        }


        public ClienteAdmin()
        {
            InitializeComponent();    
            
        }

       

        public void poblarCombos() {

            poblarTipos();
            poblarActiv();
        }


        public void poblarTipos() {
            ServiceTipo _service = new ServiceTipo();
            List<TipoEmpresa> l_tipoempresa = _service.getEntities();
            foreach (TipoEmpresa t in l_tipoempresa) {

                TipoEmpresaComboBox.Items.Add(  new KeyValuePair<int,string>(t.IdTipoEmpresa,t.Descripcion)  );
                 } 
        }

        public void poblarActiv()
            {
                ServiceActividad _servic = new ServiceActividad();
                List<ActividadEmpresa> l_actividadEmpresas = _servic.getEntities();
                foreach (ActividadEmpresa a in l_actividadEmpresas) 
            {
                ActividadComboBox.Items.Add(new KeyValuePair<int, string>(a.IdActividadEmpresa, a.Descripcion));
               
            }


            }
            
        



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clienteViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clienteViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // clienteViewSource.Source = [generic data source]

              
            System.Windows.Data.CollectionViewSource tipoEmpresaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tipoEmpresaViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // tipoEmpresaViewSource.Source = [generic data source]

            poblarCombos();
        }

        private void LimpiarCampos()
        {
            rutClienteTextBox.Text = string.Empty;
            razonSocialTextBox.Text = string.Empty;
            nombreContactoTextBox.Text = string.Empty;
            mailContactoTextBox.Text = string.Empty;
            telefonoTextBox.Text = string.Empty;
            
            direccionTextBox.Text = string.Empty;
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            ServiceCliente _servicio = new ServiceCliente();
            Cliente _cliente = new Cliente();
            _cliente = getClienteForm();


            _cliente.RutCliente = rutClienteTextBox.Text;
            _cliente.RazonSocial = razonSocialTextBox.Text;
            _cliente.NombreContacto = nombreContactoTextBox.Text;
            _cliente.MailContacto = mailContactoTextBox.Text;
            _cliente.Telefono = telefonoTextBox.Text;
            _cliente.IdActividadEmpresa = ((int) ActividadComboBox.SelectedValue); 
            _cliente.IdTipoEmpresa = ((int)TipoEmpresaComboBox.SelectedValue);
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
