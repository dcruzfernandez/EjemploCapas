using System;
using Entidades;
using System.Data;
using System.Data.SqlClient; //agregar nuGet System.Data.SqlClient
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos
{
    //capa de acceso a datos
    public class ADClientes
    {
        #region Constructor
            public ADClientes()
            {
                _Cadenaconexion = string.Empty;
                _mensaje = string.Empty;
            }
            public ADClientes(string CadenaConexion)
            {
                _Cadenaconexion = CadenaConexion;
                _mensaje = string.Empty;
            }

        #endregion

        #region Atributos
            string _Cadenaconexion;
            private string _mensaje;
        #endregion

        #region Propiedades
            public string Mensaje
            {
                get => _mensaje;
            }
        #endregion

        #region metodos

        public int Insertar(EntidadCliente pvo_EntidadCliente)
        {
            SqlConnection sqlConexion = new SqlConnection(_Cadenaconexion);
            SqlCommand sqlCommand = new SqlCommand();
            int idCliente = 0;
            string Sentencia = string.Empty; //tambien se puede usar ""
            sqlCommand.Connection = sqlConexion;
            try
            {
                Sentencia = "INSERT INTO CLIENTES(NOMBRE,DIRECCION,TELEFONO) VALUES (@Nombre,@Direccion,@Telefono) SELECT @@Identity";
                sqlCommand.Parameters.AddWithValue("@Nombre", pvo_EntidadCliente.NOMBRE);
                sqlCommand.Parameters.AddWithValue("@Direccion", pvo_EntidadCliente.DIRECCION);
                sqlCommand.Parameters.AddWithValue("@Telefono", pvo_EntidadCliente.TELEFONO);
                sqlCommand.CommandText = Sentencia;
                sqlConexion.Open();
                idCliente = Convert.ToInt32(sqlCommand.ExecuteScalar());
                sqlConexion.Close();
            }
            catch (Exception)
            {
                idCliente = -1;
                throw;
            }
            finally
            {
                sqlConexion.Dispose();
                sqlCommand.Dispose();
            }
            return idCliente;
        }//fin de insertar

        public int Modificar(EntidadCliente EntidadCliente)
        {
            int resultado = -1;
            SqlConnection Conexion = new SqlConnection(_Cadenaconexion);
            SqlCommand Command = new SqlCommand();
            string Sentencia;
            Command.Connection = Conexion;
            Command.Parameters.AddWithValue("@Id_cliente", EntidadCliente.ID_CLIENTE);
            Command.Parameters.AddWithValue("@Nombre", EntidadCliente.NOMBRE);
            Command.Parameters.AddWithValue("@Direccion", EntidadCliente.DIRECCION);
            Command.Parameters.AddWithValue("@Telefono", EntidadCliente.TELEFONO);
            Sentencia = "UPDATE CLIENTES SET NOMBRE=@Nombre,DIRECCION=@Direccion, TELEFONO=@Telefono WHERE ID_CLIENTE=@Id_Cliente";
            try
            {
                Command.CommandText = Sentencia;
                Conexion.Open();
                resultado = Command.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception)
            {
                resultado = -1;
                throw;
            }
            finally
            {
                Command.Dispose();
                Conexion.Dispose();
            }
            return resultado;
        }// fin de modificar

        public int Eliminar(EntidadCliente EntidadCliente)
        {
            int resultado = -1;
            SqlConnection Conexion = new SqlConnection(_Cadenaconexion);
            SqlCommand Command = new SqlCommand();
            string Sentencia;
            Command.Connection = Conexion;
            Command.Parameters.AddWithValue("@Id_Cliente", EntidadCliente.ID_CLIENTE);
            Sentencia = "DELETE FROM CLIENTES WHERE ID_CLIENTE=@Id_Cliente";
            Command.CommandText = Sentencia;
            try
            {
                Conexion.Open();
                Command.ExecuteNonQuery();
                resultado = 1;
                Conexion.Close();
            }
            catch (Exception)
            {
                resultado = -1;
                throw;
            }
            finally
            {
                Command.Dispose();
                Conexion.Dispose();
            }
            return resultado;
        }//fin eliminar
        public int EliminarConProcedimiento(EntidadCliente EntidadCliente)
        {
            int resultado = -1;
            SqlConnection Conexion = new SqlConnection(_Cadenaconexion);
            SqlCommand Command = new SqlCommand();
            string Sentencia = "Eliminar1";
            Command.Connection = Conexion;
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@IdCliente", EntidadCliente.ID_CLIENTE);
            //registrar el parametro de salida
            Command.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            Command.CommandText = Sentencia;
            try
            {
                Conexion.Open();
                Command.ExecuteNonQuery();
                //obtener el parametro de salida
                _mensaje = Convert.ToString(Command.Parameters["@msj"].Value);
                resultado = 1;
                Conexion.Close();
            }
            catch (Exception)
            {
                resultado = -1;
                throw;
            }
            finally
            {
                Command.Dispose();
                Conexion.Dispose();
            }
            return resultado;
        }//fin eliminar
        public EntidadCliente ObtenerRegistro(string Condicion)
        {
            EntidadCliente EntidadCliente = new EntidadCliente();
            SqlConnection vlo_Conexion = new SqlConnection(_Cadenaconexion);
            SqlCommand vlo_Command = new SqlCommand();
            SqlDataReader vloDataReader;
            string Sentencia;

            vlo_Command.Connection = vlo_Conexion;

            Sentencia = "Select ID_CLIENTE,NOMBRE,TELEFONO,DIRECCION from CLIENTES";


            if (!string.IsNullOrEmpty(Condicion))
            {
                Sentencia = string.Format("{0} WHERE {1}", Sentencia, Condicion);
            }
            try
            {
                vlo_Command.CommandText = Sentencia;
                vlo_Conexion.Open();
                vloDataReader = vlo_Command.ExecuteReader();

                if (vloDataReader.HasRows)
                {
                    vloDataReader.Read();
                    EntidadCliente.ID_CLIENTE = vloDataReader.GetInt32(0);
                    EntidadCliente.NOMBRE = vloDataReader.GetString(1);
                    EntidadCliente.TELEFONO = vloDataReader.GetString(2);
                    if(!vloDataReader.IsDBNull(3))
                        EntidadCliente.DIRECCION = vloDataReader.GetString(3);
                    EntidadCliente.EXISTE = true;
                }
                vlo_Conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                vlo_Command.Dispose();
                vlo_Conexion.Dispose();
            }
            return EntidadCliente;
        }//FIN OBTENER REGISTRO
        public DataSet ListarRegistros(string Condicion)
        {
            DataSet vlo_DataSet = new DataSet();
            SqlConnection vlo_Conexion = new SqlConnection(_Cadenaconexion);
            SqlDataAdapter vlo_DataAdapter;
            string Sentencia = string.Empty;

            try
            {
                Sentencia = "Select ID_CLIENTE,NOMBRE,TELEFONO,DIRECCION from CLIENTES";

                if (!string.IsNullOrEmpty(Condicion))
                {
                    Sentencia = string.Format("{0} WHERE {1}", Sentencia, Condicion);
                }
                vlo_DataAdapter = new SqlDataAdapter(Sentencia, vlo_Conexion);
                vlo_DataAdapter.Fill(vlo_DataSet, "Clientes");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                vlo_Conexion.Dispose();
            }
            return vlo_DataSet;
        }
        //listar registros obteniendo un arrayList
        public List<EntidadCliente> ListarRegistrosList(string condicion = "")
        {
            DataSet DS = new DataSet();
            SqlConnection vlo_conexion = new SqlConnection(_Cadenaconexion);
            SqlDataAdapter vlo_adapter;
            List<EntidadCliente> Lista = new List<EntidadCliente>();
            string sentencia;
            try
            {
                sentencia = "Select ID_CLIENTE, NOMBRE, TELEFONO, DIRECCION from CLIENTES";
                if (!string.IsNullOrEmpty(condicion))
                {
                    sentencia = string.Format("{0} where {1}", sentencia, condicion);
                }
                vlo_adapter = new SqlDataAdapter(sentencia, vlo_conexion);
                vlo_adapter.Fill(DS, "Clientes");
                //sentencia linq para crear una lista a partir de un DataTable
                Lista = (from DataRow registro in DS.Tables[0].Rows
                         select new EntidadCliente()
                         {
                             ID_CLIENTE = (int)registro[0],
                             NOMBRE = registro[1].ToString(),
                             TELEFONO = registro[2].ToString(),
                             DIRECCION = registro[3].ToString()
                         }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }//listar registros
        #endregion
    }
}
