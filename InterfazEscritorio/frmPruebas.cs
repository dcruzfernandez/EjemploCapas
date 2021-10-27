using System;
using System.Windows.Forms;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Entidades;
using System.Collections;

namespace InterfazEscritorio
{
    public partial class frmPruebas : Form
    {
        public frmPruebas()
        {
            InitializeComponent();

            //double x = 1234.7;
            //int a;
            //// Conversión de double a int.
            //a = (int)x;


            //int numVal = int.Parse("-105");
            //MessageBox.Show(numVal.ToString());

            //int resultado;
            //bool esPosible = int.TryParse("-105", out resultado);

            //if (esPosible)
            //    MessageBox.Show(resultado.ToString());

            //string input = "2345";
            //int valor = Convert.ToInt32(input);

            //double xy = 13 / 2.0;
            //MessageBox.Show("xy"+ xy.ToString());

            //int contador = 8;
            //string mensaje;

            //switch (contador) {
            //    case 1:
            //        mensaje = "Existe un elemento";
            //        break;
            //    case 2:
            //    case 3:
            //        mensaje = "Existen 2 o 3 elementos";
            //        break;
            //    case 4:
            //        mensaje = "Existen 4 elementos";
            //        break;
            //    default:
            //        mensaje = "Existen más de 4 elemento";
            //        break;
            //}
            //MessageBox.Show(mensaje);

            //crea un arreglo A con 5 elementos inicializados en 0
            
            //int[] A = { 15, 20, 3, 4 };
            
            ////MostrarArreglo(A);
            //string cadena = "Manzanas, Uvas, Peras, Papayas";
            //string[] frutas = new string[10];
            //frutas = cadena.Split(',');

            //List<int> Valores = new List<int>();
            //for (int i = 1; i <= 10; i++) {
            //    Valores.Add(i);
            //}
            //Valores.Insert(3, 20);
            //int indice = Valores.IndexOf(5);
            //Valores.Remove(7);

            //MostrarArreglo(Valores);
            //Valores.Clear();

            ArrayList Lista = new ArrayList();
            //int[] arregloPrueba = new int[10];
            //Lista.Add(2); //Se pueden agregar valores de diferentes tipos
            //Lista.Add(10);
            //Lista.Add(8);
            //Lista.Sort();
            //if (Lista.Contains(8)) {
            //    MessageBox.Show("El 8 está en el índice " + Lista[Lista.IndexOf(8)].ToString());
            //}
            //Lista.Insert(1, 15);//en la posición 1 inserta el 15
            //Lista.CopyTo(arregloPrueba);
            //Lista.Remove(10);//Elimina el primer elemento que coincida con el parámetro
            //Array.Clear(arregloPrueba, 3, 2); //elimina 2 elementos a partir del índice 3

            //ArrayList ListaObjetos = new ArrayList();
            //ListaObjetos.Add("Texto1");
            //ListaObjetos.Add("Texto2");
            //ListaObjetos.Add(5);
            //ListaObjetos.Add(2.3);
            //ListaObjetos.Add(true);

            //MostrarArreglo(ListaObjetos);

            int[] valores = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            int contador = 0;
            double total = 0;
            double promedio = CalcularPromedio(valores, ref total, out contador);

            //crea un arreglo B con 5 elementos de tipo EntidadCliente
            //inicializados en null ya que se deben crear instancias
            //para cada elemento individualmente
            EntidadCliente[] B = new EntidadCliente[5];

            MessageBox.Show("Hola");
        }

        public void MostrarArreglo(IEnumerable myArray) {
            foreach (object item in myArray) {
                MessageBox.Show(item.ToString());
            }
        }

        public double CalcularPromedio(int[] datos, ref double suma, out int cantidad) {
            //debe cambiar antes de terminar el proceso
            cantidad = datos.Length;
            for (int i = 0; i < cantidad; i++) {
                suma += datos[i];
            }
            return suma / cantidad;
        }
    }
}
