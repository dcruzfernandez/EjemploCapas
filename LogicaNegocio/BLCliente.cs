using System;
using System.Collections.Generic;
using System.Data;
using Entidades;
using AccesoDatos;

namespace LogicaNegocio
{
    public class BLCliente
    {
        private string _mensaje;
        private string _cadenaConexion;

        public string Mensaje
        {
            get => _mensaje;
        }

        #region Constructor
            public BLCliente()
            {
                _mensaje = string.Empty;
                _cadenaConexion = string.Empty;
            }
            public BLCliente(string cadenaConexion)
            {
                _mensaje = string.Empty;
                _cadenaConexion = cadenaConexion;
            }
        #endregion

        #region Metodos
        public int InsertarCliente(EntidadCliente EntidadCliente)
        {
            int Resultado;
            ADClientes AccesoDatosCliente=new ADClientes(_cadenaConexion);
            try
            {
                Resultado = AccesoDatosCliente.Insertar(EntidadCliente);

            }
            catch (Exception)
            {
                throw;
            }
            return Resultado;
        }
        //********************************************************************************
        public int ModificarCliente(EntidadCliente EntidadCliente)
        {
            int Resultado;
            ADClientes AccesoDatosCliente = new ADClientes(_cadenaConexion);
            try
            {
                Resultado = AccesoDatosCliente.Modificar(EntidadCliente);
            }
            catch (Exception)
            {

                throw;
            }
            return Resultado;
        }
        //**********************************************************************************
        public int EliminarCliente(EntidadCliente EntidadCliente)
        {
            int Resultado = 0;
            ADClientes AccesoDatosCliente = new ADClientes(_cadenaConexion);
            try
            {
                Resultado = AccesoDatosCliente.EliminarConProcedimiento(EntidadCliente);
                _mensaje = AccesoDatosCliente.Mensaje;
            }
            catch (Exception)
            {

                throw;
            }
            return Resultado;
        }
        //**********************************************************************************
        public EntidadCliente ObtenerCliente(string Condicion)
        {
            EntidadCliente EntidadCliente;
            ADClientes AccesoDatosCliente = new ADClientes(_cadenaConexion);
            try
            {
                EntidadCliente = AccesoDatosCliente.ObtenerRegistro(Condicion);
            }
            catch (Exception)
            {

                throw;
            }
            return EntidadCliente;
        }
        //************************************************************************************
        public DataSet ListarCliente(string Condicion)
        {
            DataSet DSCliente;
            ADClientes AccesoDatosCliente = new ADClientes(_cadenaConexion);
            try
            {
                DSCliente = AccesoDatosCliente.ListarRegistros(Condicion);
            }
            catch (Exception)
            {

                throw;
            }
            return DSCliente;
        }

        public List<EntidadCliente> ListarRegistros1(string condicion = "")
        {
            List<EntidadCliente> Lista;
            ADClientes AccesoDatosCliente = new ADClientes(_cadenaConexion);
            try
            {
                Lista = AccesoDatosCliente.ListarRegistrosList(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }//listasregistros
        #endregion
    }
}
