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
    public partial class frmFacturar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet reserva;
            BLReservacion LogicaR = new BLReservacion(clsConfig.getconnectionString);
            string condicion;
            try
            {
                if (!Page.IsPostBack)
                {
                    
                    Session["_mensaje"] = null;
                    if (Session["Id_Reserva"] != null)
                    {
                        condicion = string.Format("NUMRESERVACION={0}", Session["Id_Reserva"].ToString());
                        reserva = LogicaR.ListarRegistros(condicion);
                        if (reserva.Tables[0].Rows.Count > 0) {
                            ltlReserva.Text = $"Reservación #: {reserva.Tables[0].Rows[0]["NumReservacion"]}";
                            ltlCliente.Text = $"Cliente: {reserva.Tables[0].Rows[0]["Nombre"]}";
                            ltlingreso.Text = reserva.Tables[0].Rows[0]["fechaingreso"].ToString();
                            ltlsalida.Text = reserva.Tables[0].Rows[0]["fechasalida"].ToString();
                            ltlnoches.Text= reserva.Tables[0].Rows[0]["noches"].ToString();
                            ltlpersonas.Text= reserva.Tables[0].Rows[0]["cantidadpersonas"].ToString();
                            ltltipo.Text = reserva.Tables[0].Rows[0]["tipohabitacion"].ToString();
                            ltlprecio.Text = reserva.Tables[0].Rows[0]["precioxn"].ToString();
                            ltlSubtotal.Text= reserva.Tables[0].Rows[0]["subtotal"].ToString();
                            ltlICT.Text= reserva.Tables[0].Rows[0]["ict"].ToString();
                            ltliva.Text = reserva.Tables[0].Rows[0]["iva"].ToString();
                            ltlTotal.Text = (double.Parse(ltlSubtotal.Text)+
                                double.Parse(ltlICT.Text)+ double.Parse(ltliva.Text)).ToString();
                        }
                       
                    }
                    else
                    {
                        Session["_mensaje"] = "Error al Cargar la reserva";

                    }

                }
            }
            catch (Exception)
            {

                Session["_mensaje"] = "Error al Cargar la reserva";
                Response.Redirect("frmListaReserva.aspx");
            }
        }

        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            BLReservacion logicaR = new BLReservacion(clsConfig.getconnectionString);
            int id;
            try
            {
                if (Session["Id_Reserva"] != null)
                {
                    id = int.Parse(Session["Id_Reserva"].ToString());
                    logicaR.FacturarReserva(id);
                    Session["_mensaje"] = "Reserva facturada satisfactoriamente";
                    Response.Redirect("frmListaReserva.aspx",false);
                }
            }
            catch (Exception)
            {

                Session["_mensaje"] = "Error al realizar el pago";
                Response.Redirect("frmListaReserva.aspx");
            }
        }

        protected void btnAtrás_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmListaReserva.aspx");
        }
    }
}