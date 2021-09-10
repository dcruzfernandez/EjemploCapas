using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;


namespace InterfazEscritorio
{
    public partial class frmClientes : Form
    {
        //variables globales
        EntidadCliente EntidadRegistrada;
        frmBuscarClientes buscar;
        public frmClientes()
        {
            InitializeComponent();
        }
        //métodos
        private void Limpiar()
        {
            //metodo para limpiar
            txtId_Cliente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtNombre.Focus();
        }
        private EntidadCliente GenerarEntidad()
        {
            //crear una entidad apartir de datos nuevos o de registros existentes
            EntidadCliente cliente;
            if (!string.IsNullOrEmpty(txtId_Cliente.Text))
            {
                cliente = EntidadRegistrada;
            }
            else
            {
                cliente = new EntidadCliente();
            }
            cliente.NOMBRE = txtNombre.Text;
            cliente.TELEFONO = txtTelefono.Text;
            cliente.DIRECCION = txtDireccion.Text;
            return cliente;
        }
        private void CargarLista(string condicion = "")
        {
            //usando un objeto list
            BLCliente logica = new BLCliente(clsConfiguracion.getconnectionString);
            List<EntidadCliente> DS;
            try
            {
                DS = logica.ListarRegistros1(condicion);
                if (DS.Count > 0)
                {
                    grdLista.DataSource = DS;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarListaDataSet(string condicion = "")
        {
            BLCliente logica = new BLCliente(clsConfiguracion.getconnectionString);
            DataSet DS;
            try
            {
                DS = logica.ListarCliente(condicion);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    grdLista.DataSource = DS;
                    grdLista.DataMember = DS.Tables[0].TableName;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarCliente(int id)
        {
            EntidadCliente cliente;
            BLCliente logica = new BLCliente(clsConfiguracion.getconnectionString);
            string condicion = string.Format("ID_CLIENTE={0}", id);
            try
            {
                cliente = logica.ObtenerCliente(condicion);
                if (cliente.EXISTE)
                {
                    txtId_Cliente.Text = cliente.ID_CLIENTE.ToString();
                    txtNombre.Text = cliente.NOMBRE;
                    txtTelefono.Text = cliente.TELEFONO;
                    txtDireccion.Text = cliente.DIRECCION;
                    EntidadRegistrada = cliente;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //**********************************************
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            BLCliente logica = new BLCliente(clsConfiguracion.getconnectionString);
            EntidadCliente cliente;
            int resultado;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) &&
                    !string.IsNullOrEmpty(txtTelefono.Text) &&
                    !string.IsNullOrEmpty(txtDireccion.Text))
                {
                    cliente = GenerarEntidad();
                    if (cliente.EXISTE == false)
                    {
                        //si el cliente es nuevo
                        resultado = logica.InsertarCliente(cliente);
                    }
                    else
                    {
                        //si el cliente se va a modificar
                        resultado = logica.ModificarCliente(cliente);
                    }
                    if (resultado > 0)
                    {
                        Limpiar();
                        CargarLista();
                        MessageBox.Show("Operación realizada satisfactoriamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se puede realizar la operación, favor verifique los datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No se puede realizar la operación, debe completar todos los datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                CargarLista();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = 0;
            try
            {
                id = (int)grdLista.SelectedRows[0].Cells[0].Value;
                CargarCliente(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BLCliente logica = new BLCliente(clsConfiguracion.getconnectionString);
            EntidadCliente cliente;
            string condicion;
            int resultado = -1;
            try
            {
                if (!string.IsNullOrEmpty(txtId_Cliente.Text))
                {
                    condicion = string.Format("ID_CLIENTE={0}", txtId_Cliente.Text);
                    cliente = logica.ObtenerCliente(condicion);
                    if (cliente.EXISTE)
                    {
                        //usando el SP de la bd
                        resultado = logica.EliminarCliente(cliente);
                        if (resultado > 0)
                        {
                            MessageBox.Show(logica.Mensaje);
                            CargarLista();
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(logica.Mensaje);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cliente no existe");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el cliente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar = new frmBuscarClientes();
            buscar.Aceptar += new EventHandler(Aceptar);
            buscar.Show();
        }

        private void Aceptar(object id, EventArgs e)
        {
            try
            {
                int id_seleccionado = (int)id;
                if (id_seleccionado != -1)
                {
                    CargarCliente(id_seleccionado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }//clase
}//namespace
