using System;

namespace Entidades
{
    [Serializable()]
    public class EntidadCliente
    {
        #region Contructor
            public EntidadCliente()
            {
                idCliente = 0;
                nombre = string.Empty;
                direccion = string.Empty;
                telefono = string.Empty;
                existeRegistro = false;
            }

            public EntidadCliente(int id, string nombre, string ptelefono,
                string pdireccion, bool pexiste)
            {
                idCliente = id;
                this.nombre = nombre;
                direccion = pdireccion;
                telefono = ptelefono;
                existeRegistro = pexiste;
            }
        #endregion

        #region Atributos


            private int idCliente;
            private string nombre;
            private string direccion;
            private string telefono;
            private bool existeRegistro;

        #endregion

        #region Propiedades

            public int ID_CLIENTE
            {
                get
                {
                    return idCliente;
                }
                set
                {
                    idCliente = value;
                }
            }

            public string NOMBRE
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public string DIRECCION { get => direccion; set => direccion = value; }

            //public string Direccion { get; set; }
            public string TELEFONO
            {
                get { return telefono; }
                set { telefono = value; }
            }

            public bool EXISTE
            {
                get { return existeRegistro; }
                set { existeRegistro = value; }
            }
        #endregion
    }
}
