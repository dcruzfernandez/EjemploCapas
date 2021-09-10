using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;
using System.Data;

namespace InterfazWeb
{
    public partial class Default : System.Web.UI.Page
    {
        //***********************
        string _Script;
        //***********************
        private void LimpiarCampos()
        {

            txtnombre.Text = string.Empty;
            txtnombre.Focus();
        }

        private void CargarListaClientes(string condicion = "")
        {
            DataSet dsDatos;
            BLCliente LogicaCliente = new BLCliente(clsConfig.getconnectionString);

            try
            {
                dsDatos = LogicaCliente.ListarCliente(condicion);

                if (dsDatos != null)
                {
                    grdLista.DataSource = dsDatos;
                    grdLista.DataMember = dsDatos.Tables[0].TableName;
                    grdLista.DataBind();
                }
            }

            catch (Exception)
            {
                throw;
            }
        }
        //*****************************
        private void BorrarCliente(int pvn_idCliente)
        {
            BLCliente vlo_LogicaCliente = new BLCliente(clsConfig.getconnectionString);
            EntidadCliente vlo_EntidadCliente = new EntidadCliente();
            string vlc_Condicion;


            try
            {
                vlc_Condicion = string.Format("ID_CLIENTE = {0}", pvn_idCliente.ToString());
                vlo_EntidadCliente = vlo_LogicaCliente.ObtenerCliente(vlc_Condicion);

                if (vlo_EntidadCliente.EXISTE)
                {
                    if (vlo_LogicaCliente.EliminarCliente(vlo_EntidadCliente) > 0)
                    {
                        _Script = string.Format("javascript:pageMostrarMensaje('Operación realizada satisfactoriamente');");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", _Script, true);

                    }
                    LimpiarCampos();
                    CargarListaClientes();
                }
            }

            catch (Exception)
            {
                throw;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    CargarListaClientes();
                    LimpiarCampos();
                }
            }
            catch (Exception)
            {

                _Script = string.Format("javascript:pageMostrarMensaje('Error al cargar la lista de clientes');");
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", _Script, true);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string vln_condicion = string.Format("nombre like '%{0}%'", txtnombre.Text);
            CargarListaClientes(vln_condicion);
        }

        protected void grdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdLista.PageIndex = e.NewPageIndex;
            CargarListaClientes();
        }

        

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Session.Remove("Id_Cliente");
            Response.Redirect("FrmClientes.aspx");
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["Id_Cliente"] = e.CommandArgument.ToString();
            Response.Redirect("frmClientes.aspx");
        }

        protected void lnkBorrar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                BorrarCliente(int.Parse(e.CommandArgument.ToString()));
            }
            catch (Exception)
            {

                _Script = string.Format("javascript:pageMostrarMensaje('Error al eliminar un cliente verifique que no tiene referencias con otras entidades');");
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", _Script, true);
            }
        }
    }
}