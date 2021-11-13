using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EntidadReservacion
    {
        private int numReservacion;
        private int cantidadPersonas;
        private DateTime fechaIngreso, fechaSalida;
        private string tipoHabitacion;
        private bool cancelada, existe;
        private decimal precioxn;
        private EntidadCliente cliente;

        public EntidadReservacion()
        {
            numReservacion = 0;
            cliente = new EntidadCliente();
            cantidadPersonas = 0;
            fechaIngreso = DateTime.Today;
            fechaSalida = DateTime.Today;
            tipoHabitacion = string.Empty;
            precioxn = 0;
            cancelada = false;
            existe = false;

        }

        public EntidadReservacion(int pvn_numReservacion,
                                    EntidadCliente pvo_Cliente,
                                    int pvn_cantidad,
                                    DateTime pvd_fechaI,
                                    DateTime pvd_fechaS,
                                    string pvc_tipo,
                                    decimal pvn_precio,
                                    bool pvb_cancelada)
        {
            numReservacion = pvn_numReservacion;
            cliente = pvo_Cliente;
            cantidadPersonas = pvn_cantidad;
            fechaIngreso = pvd_fechaI;
            fechaSalida = pvd_fechaS;
            tipoHabitacion = pvc_tipo;
            cancelada = pvb_cancelada;
            precioxn = pvn_precio;
            existe = true;

        }

        public int NumReservacion { get => numReservacion; set => numReservacion = value; }
        public int CantidadPersonas { get => cantidadPersonas; set => cantidadPersonas = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public DateTime FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public string TipoHabitacion { get => tipoHabitacion; set => tipoHabitacion = value; }
        public bool Cancelada { get => cancelada; set => cancelada = value; }
        public bool Existe { get => existe; set => existe = value; }
        public decimal Precioxn { get => precioxn; set => precioxn = value; }
        public EntidadCliente Cliente { get => cliente; set => cliente = value; }
    }
}
