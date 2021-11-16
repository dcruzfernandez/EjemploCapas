using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using AccesoDatos;
using System.Data;

namespace LogicaNegocio
{
    public class BLReservacion
    {
        private string _mensaje;
        private string _cadenaConexion;

        public string Mensaje
        {
            get => _mensaje;
        }
        public BLReservacion(string cadenaConexion)
        {
            _mensaje = string.Empty;
            _cadenaConexion = cadenaConexion;
        }
        //métodos

        public int InsertarReserva(EntidadReservacion Reservacion)
        {
            int Resultado;
            ADReservacion AccesoDatosR = new ADReservacion(_cadenaConexion);
            try
            {
                if (Reservacion.TipoHabitacion == "Standard")
                {
                    Reservacion.Precioxn = 80;
                }
                else if (Reservacion.TipoHabitacion == "Junior")
                {
                    Reservacion.Precioxn = 120;
                }
                else
                {
                    Reservacion.Precioxn = 180;
                }
                Reservacion.Cancelada = false;
                Resultado = AccesoDatosR.Insertar(Reservacion);
                if (Resultado > 0) {
                    _mensaje = "Operación realizada satisfactoriamente";
                }
                else {
                    _mensaje = "Imposible realizar la operación";
                }

            }
            catch (Exception)
            {
                throw;
            }
            return Resultado;
        }
        //********************************************************************************
        public int ModificarReserva(EntidadReservacion Reservacion)
        {
            int Resultado;
            ADReservacion AccesoDatosR = new ADReservacion(_cadenaConexion);
            try
            {
                if (!Reservacion.Cancelada)
                {
                    if (Reservacion.TipoHabitacion == "Standard")
                    {
                        Reservacion.Precioxn = 80;
                    }
                    else if (Reservacion.TipoHabitacion == "Junior")
                    {
                        Reservacion.Precioxn = 120;
                    }
                    else
                    {
                        Reservacion.Precioxn = 180;
                    }
                    Resultado = AccesoDatosR.Modificar(Reservacion);
                    _mensaje = "Reserva modificada satisfactoriamente";
                }
                else {
                    Resultado = -1;
                    _mensaje = "Imposible modificar la reserva debido a que ya canceló la factura";
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            return Resultado;
        }
        public int FacturarReserva(int Reservacion)
        {
            int Resultado;
            ADReservacion AccesoDatosR = new ADReservacion(_cadenaConexion);
            try
            {
                Resultado = AccesoDatosR.FacturarReserva(Reservacion);
            }
            catch (Exception)
            {

                throw;
            }
            return Resultado;
        }
        //**********************************************************************************
        public int EliminarReserva(EntidadReservacion Reservacion)
        {
            int Resultado = 0;
            ADReservacion adReserva = new ADReservacion(_cadenaConexion);
            try
            {
                if (adReserva.ObtenerRegistro($"NUMRESERVACION={Reservacion.NumReservacion}").Cancelada)
                {
                    _mensaje = "Imposible eliminar la reserva ya que la factura ya se canceló";
                    Resultado = -1;
                }
                else
                {
                    Resultado = adReserva.Eliminar(Reservacion);
                    if (Resultado > 0)
                        _mensaje = "La reserva se eliminó satisfactoriamente";
                    else
                        _mensaje = "No se pudo completar la operación";
                }

            }
            catch (Exception)
            {

                throw;
            }
            return Resultado;
        }
        //**********************************************************************************
        public EntidadReservacion ObtenerReserva(string Condicion)
        {
            EntidadReservacion EntidadReserva;
            ADReservacion AccesoDatosR = new ADReservacion(_cadenaConexion);
            try
            {
                EntidadReserva= AccesoDatosR.ObtenerRegistro(Condicion);
            }
            catch (Exception)
            {

                throw;
            }
            return EntidadReserva;
        }
        //************************************************************************************
        public DataSet ListarRegistros(string Condicion)
        {
            DataSet DS;
            ADReservacion AccesoDatosR = new ADReservacion(_cadenaConexion);
            try
            {
                DS = AccesoDatosR.ListarRegistros(Condicion);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }

        
    }
}
