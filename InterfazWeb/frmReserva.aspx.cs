using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace InterfazWeb
{
    public partial class frmReserva : System.Web.UI.Page
    {
        //métodos
        private EntidadReservacion GenerarEntidad()
        {
            EntidadReservacion reserva = new EntidadReservacion();

            if (Session["Id_Reserva"] != null)
            {
                reserva.NumReservacion = int.Parse(Session["Id_Reserva"].ToString());
                reserva.Existe = true;
            }
            else
            {
                reserva.NumReservacion = -1;
                reserva.Existe = false;                
            }

            reserva.Cliente.ID_CLIENTE = int.Parse(txtidseleccionado.Text);
            reserva.FechaIngreso = DateTime.Parse(txtfechaI.Text);
            reserva.FechaSalida = DateTime.Parse(txtfechaF.Text);
            reserva.CantidadPersonas = int.Parse(txtpersonas.Text);
            reserva.TipoHabitacion = cbotipo.SelectedValue.ToString();
            reserva.Cancelada = false;

            return reserva;
        }
        private void LimpiarCampos()
        {
            txtidseleccionado.Text = string.Empty;
            txtcliente.Text = string.Empty;
            txtnombrecliente.Text = string.Empty;
            txtfechaActual.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtfechaF.Text = string.Empty;
            txtfechaI.Text = string.Empty;
            txtpersonas.Text = string.Empty;
            txtnumreserva.Text = string.Empty;

        }
        private int Guardar()
        {
            EntidadReservacion reserva;
            BLReservacion LogicaR = new BLReservacion(clsConfig.getconnectionString);
            int resultado;

            try
            {
                reserva = GenerarEntidad();

                if (!reserva.Existe)
                {
                    resultado = LogicaR.InsertarReserva(reserva);
                }
                else
                {
                    resultado = LogicaR.ModificarReserva(reserva);
                }
                Session["_mensaje"] = LogicaR.Mensaje;

                Response.Redirect("Default.aspx", false);


            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
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
        //**********************************************************
        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadReservacion reserva;
            BLReservacion LogicaR = new BLReservacion(clsConfig.getconnectionString);
            string condicion = "";
            try
            {
                if (!Page.IsPostBack)
                {
                    CargarListaClientes();
                    Session["_mensaje"] = null;
                    if (Session["Id_Reserva"] != null)
                    {
                        condicion = string.Format("NUMRESERVACION={0}", Session["Id_Reserva"].ToString());
                        reserva = LogicaR.ObtenerReserva(condicion);
                        txtnumreserva.Text = reserva.NumReservacion.ToString();
                        txtidseleccionado.Text = reserva.Cliente.ID_CLIENTE.ToString();
                        txtcliente.Text = reserva.Cliente.NOMBRE;
                        txtfechaI.Text = reserva.FechaIngreso.ToString("dd/MM/yyyy");
                        txtfechaF.Text = reserva.FechaIngreso.ToString("dd/MM/yyyy");
                        txtpersonas.Text = reserva.CantidadPersonas.ToString();
                        cbotipo.SelectedValue = reserva.TipoHabitacion;
                        txtfechaActual.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        LimpiarCampos();
                        
                    }

                }
            }
            catch (Exception)
            {

                Session["_mensaje"] = "Error al Cargar la reserva";
                Response.Redirect("Default.aspx");
            }
        }

        protected void grdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdLista.PageIndex = e.NewPageIndex;
            CargarListaClientes();
            string javaScript = "AbrirModal();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = string.Format("nombre like '%{0}%'", txtnombrecliente.Text);
            CargarListaClientes(condicion);
            string javaScript = "AbrirModal();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void lnkSeleccionar_Command(object sender, CommandEventArgs e)
        {
            BLCliente LogicaCliente = new BLCliente(clsConfig.getconnectionString);
            EntidadCliente cliente;
            int id = int.Parse(e.CommandArgument.ToString());
            txtidseleccionado.Text= id.ToString();
            cliente = LogicaCliente.ObtenerCliente($"ID_CLIENTE={id}");
            txtcliente.Text = cliente.NOMBRE;
        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {
            try
            {

                Guardar();
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = ex.Message;/*"Error al guardar la resrva";*/

            }
        }
    }
}