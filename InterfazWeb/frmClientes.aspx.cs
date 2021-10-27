using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;

namespace InterfazWeb
{
    public partial class frmClientes : System.Web.UI.Page
    {
        //***************************
        string _Script;

        //*********************************
        private int GuardarCliente()
        {
            EntidadCliente entidadCliente;
            BLCliente LogicaCliente = new BLCliente(clsConfig.getconnectionString);
            int resultado = 0;

            try
            {
                entidadCliente = GenerarCliente();

                if (!entidadCliente.EXISTE)
                {
                    resultado = LogicaCliente.InsertarCliente(entidadCliente);
                }
                else
                {
                    resultado = LogicaCliente.ModificarCliente(entidadCliente);
                }


                if (resultado > 0)
                {
                    _Script = String.Format("javascript:pageMostrarMensaje('Operación realizada satisfactoriamente');");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", _Script, true);
                }
                Response.Redirect("Default.aspx");


            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        private void LimpiarCampos()
        {
            txtID.Text = string.Empty;
            TxtNombre.Text = string.Empty;
            TxtDireccion.Text = string.Empty;
            TxtTelefono.Text = string.Empty;
        }
        private EntidadCliente GenerarCliente()
        {
            EntidadCliente entidadCliente = new EntidadCliente();

            if (Session["Id_Cliente"] != null)
            {
                entidadCliente.ID_CLIENTE = int.Parse(Session["Id_Cliente"].ToString());
                entidadCliente.EXISTE = true;
            }
            else
            {
                entidadCliente.ID_CLIENTE = -1;
                entidadCliente.EXISTE = false;
            }
            entidadCliente.NOMBRE = TxtNombre.Text.Trim();
            entidadCliente.DIRECCION = TxtDireccion.Text.Trim();
            entidadCliente.TELEFONO = TxtTelefono.Text.Trim();

            return entidadCliente;
        }

        //***************************
        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadCliente entidadCliente;
            BLCliente LogicaCliente = new BLCliente(clsConfig.getconnectionString);
            string condicion = "";
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["Id_Cliente"] != null)
                    {
                        condicion = string.Format("Id_Cliente={0}", Session["Id_Cliente"].ToString());
                        entidadCliente = LogicaCliente.ObtenerCliente(condicion);
                        txtID.Text = entidadCliente.ID_CLIENTE.ToString();
                        TxtNombre.Text = entidadCliente.NOMBRE;
                        TxtTelefono.Text = entidadCliente.TELEFONO;
                        TxtDireccion.Text = entidadCliente.DIRECCION;
                        lblID.Visible = true;
                        txtID.Visible = true;
                    }
                    else
                    {
                        LimpiarCampos();
                        txtID.Visible = false;
                        lblID.Visible = false;
                        txtID.Text = "-1";
                    }

                }
            }
            catch (Exception)
            {

                _Script = String.Format("javascript:pageMostrarMensaje('Error al Cargar el cliente');");
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", _Script, true);
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarCliente();
            }
            catch (Exception)
            {

                _Script = string.Format("javascript:pageMostrarMensaje('Error al guardar el cliente');");
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", _Script, true);
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}