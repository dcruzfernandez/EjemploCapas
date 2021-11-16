using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb
{
    public partial class frmListaReserva : System.Web.UI.Page
    {
        //MÉTODOS
        private void LimpiarCampos()
        {

            txtnombre.Text = string.Empty;
            txtnombre.Focus();
        }

        private void CargarLista(string condicion = "")
        {
            DataSet dsDatos;
            BLReservacion LogicaReserva = new BLReservacion(clsConfig.getconnectionString);
            string condicionBase = "cancelada=0";
            try
            {
                if (!string.IsNullOrEmpty(condicion)) {
                    condicionBase = $"{condicionBase} and {condicion}";
                }
                dsDatos = LogicaReserva.ListarRegistros(condicionBase);

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
        //*****************************************
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //Session["_mensaje"] = null;
                    CargarLista();
                    LimpiarCampos();
                }
            }
            catch (Exception)
            {

                Session["_mensaje"] = "Error al cargar la lista de reservas";

            }
        }
        private void BorrarReserva(int numReserva)
        {
            BLReservacion LogicaReserva = new BLReservacion(clsConfig.getconnectionString);
            EntidadReservacion reserva;
            string Condicion;


            try
            {
                Condicion = string.Format("NUMRESERVACION = {0}", numReserva.ToString());
                reserva = LogicaReserva.ObtenerReserva(Condicion);

                if (reserva.Existe)
                {
                    if (LogicaReserva.EliminarReserva(reserva) > 0)
                    {
                        Session["_mensaje"] = "Operación realizada satisfactoriamente";

                    }
                    LimpiarCampos();
                    CargarLista();
                }
            }

            catch (Exception)
            {
                throw;
            }

        }

        protected void grdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdLista.PageIndex = e.NewPageIndex;
            CargarLista();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string vln_condicion = string.Format("nombre like '%{0}%'", txtnombre.Text);
            CargarLista(vln_condicion);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Session.Remove("Id_Reserva");
            Response.Redirect("frmReserva.aspx");
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["Id_Reserva"] = e.CommandArgument.ToString();
            Response.Redirect("frmReserva.aspx");
        }

        protected void lnkBorrar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                BorrarReserva(int.Parse(e.CommandArgument.ToString()));
            }
            catch (Exception)
            {
                Session["_mensaje"] = "Error al eliminar la reserva verifique que no tiene referencias con otras entidades";

            }
        }
    }
}