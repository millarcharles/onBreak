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
using onBreak.Resources.Errors;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace onBreak.ModCliente
{
    /// <summary>
    /// Interaction logic for ClienteAdmin.xaml
    /// </summary>
    public partial class ClienteAdmin : MetroWindow
    {
        public Cliente _clienteEdit;
        ServiceCliente _clientes = new ServiceCliente();



        //ctor con parametro, recibe cliente desde lista
        public ClienteAdmin(Cliente _clienteinpt)
        {


            InitializeComponent();
            
            
            rutClienteTextBox.Text = _clienteinpt.RutCliente;
            rutClienteTextBox.IsEnabled = false;
            btnBuscarRutCliente.IsEnabled = false;
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
            btnBuscarRutCliente.IsEnabled = false;
            btnAgregarCliente.Visibility = Visibility.Hidden;

        }
        //constructor sin parametros, forma vacia para ingreso de cliente
        public ClienteAdmin()
        {
            InitializeComponent();


            //se esconden controles de modificacion y eliminacion de cliente
            btnModificarCliente.Visibility = Visibility.Hidden;
            btnEliminarCliente.Visibility = Visibility.Hidden;
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
            TipoEmpresaComboBox.SelectedIndex = -1;
            ActividadComboBox.SelectedIndex = -1;
            
            
        }


  

        private void btnModificarCliente_Click(object sender, RoutedEventArgs e)
        {
            ServiceCliente _servicio = new ServiceCliente();
            Cliente _cliente = getClienteForm();

            if (camposNotN()) { 
                try
            {
                _servicio.updEntity(_cliente.RutCliente,_cliente);
                MessageBox.Show("Cliente Modificado con exito");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());

            }
            }
        }

        private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            ServiceCliente _servicio = new ServiceCliente();
            Cliente _cliente = new Cliente(); 
              _cliente = getClienteForm();
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Desea Eliminar Cliente de los Registros?", "Confirmacion de Elinacion", System.Windows.MessageBoxButton.OKCancel);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    _servicio.delEntity((string)_cliente.RutCliente);
                    MessageBox.Show("Cliente Eliminado con exito");
                    LimpiarCampos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());

                }
            }
            else { MessageBox.Show("Operacion cancelada"); }

        }

        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
                ServiceCliente _servicio = new ServiceCliente();
                Cliente _cliente = getClienteForm();

            if (!_servicio.isEntity(_cliente.RutCliente))
            {

                if (camposNotN()) {

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
            else {

                MessageBox.Show("ERROR:  El Rut \""+_cliente.RutCliente+"\" ya fue registrado en la Base de Datos");
            }
        }
        private  bool ValidarNullorWhi(TextBox campo) {
            if (string.IsNullOrWhiteSpace(campo.Text))
                return true;
            
          return false;
        }

        private void button_Click(object sender, RoutedEventArgs e) {

            camposNotN();

            }



        public bool camposNotN() {

            ValidationResponse _validationResponse = checkCampos();
            if (!_validationResponse._successful)
            {
                MessageBox.Show("El campo \"" + _validationResponse._element + "\" No puede estar vacio");
                return false;

            }
            return true;


        }

        public ValidationResponse checkCampos() {
            
            
            ValidationResponse _response = new ValidationResponse(true, null);
            

            foreach (UIElement prop in gridCliente.Children)
            {
                    if (Grid.GetColumn(prop) == 1)
                {
                    if (prop.GetType().Equals(typeof(TextBox)))
                    {
                        // caso es textbox

                        if (String.IsNullOrWhiteSpace((prop as TextBox).Text))
                        {
                            // caso txtbx vacia
                            _response = new ValidationResponse(false, (prop as TextBox).Name);
                        }
                        else {  }
                    }
                    else
                    {//caso es combobox

                        if ( (prop as ComboBox).SelectedValue == null ) {

                            // caso cmbx vacia
                            _response = new ValidationResponse(false, (prop as ComboBox).Name);
                        }
                        
                        
                        
                    }
                }


            }

            return _response;
        
        
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(_clientes.isEntity(rutClienteTextBox.Text));
        }
    }
}
