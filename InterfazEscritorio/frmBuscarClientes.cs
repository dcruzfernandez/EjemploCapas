using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LogicaNegocio;

namespace InterfazEscritorio
{
    public partial class frmBuscarClientes : Form
    {
        //crear evento
        public event EventHandler Aceptar;
        int idcliente = 0;
        //********************************
        public frmBuscarClientes()
        {
            InitializeComponent();
        }
        //*******************************************
        private void CargarLista(string condicion = "")
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

        private void Seleccionar()
        {
            try
            {
                if (grdLista.SelectedRows.Count > 0)
                {
                    idcliente = (int)grdLista.SelectedRows[0].Cells[0].Value;
                    Aceptar(idcliente, null);
                    Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //*******************************************

        private void frmBuscarClientes_Load(object sender, EventArgs e)
        {
            try
            {
                CargarLista();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void grdLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            idcliente = -1;
            Aceptar(idcliente, null);
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion=string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtnombre.Text))
                {
                    condicion = string.Format("Nombre like '%{0}%'", txtnombre.Text.Trim());
                    
                }
                CargarLista(condicion);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }//clase
}//namespace
