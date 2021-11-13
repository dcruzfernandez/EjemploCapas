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
        //**************************************
        

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
                Session["_mensaje"] = "Operación realizada satisfactoriamente";

                Response.Redirect("Default.aspx",false);


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
                    Session["_mensaje"] = null;
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

                Session["_mensaje"]="Error al Cargar el cliente";
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                GuardarCliente();
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = ex.Message;/*"Error al guardar el cliente";*/
                
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}