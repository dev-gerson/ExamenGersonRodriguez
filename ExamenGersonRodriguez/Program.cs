using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGersonRodriguez
{
    /*
     Autor: Gerson Nehemias Rodriguez Hernandez
     Email: gersonrodrihernan@gmail.com
     Fecha: 24/01/2022
     */
    class Program
    {
        static void Main(string[] args)
        {
            int total_col3 = 0,
                total_fil1y2_col2 = 0;
            ///
            Matriz matriz = new Matriz();
            matriz.Cargar();
            matriz.Mostrar();
            matriz.LlenarCol3_Col1y2();
            total_col3 = matriz.CalcTotalCol3();
            matriz.CrearFilasyColumnas(2, 0);//- crear dos filas (vacías)
            matriz.CrearFilasyColumnas(0, 1);//- crear una columna nueva (vacía)
            matriz.TrasladaFil1y2Col1();//- Trasladar los valores de las [filas 1 y 2] [columna 1] hacia las filas nuevas
            total_fil1y2_col2 = matriz.CalcTotalFil1y2Col2();//- Calcular el total de las [filas 1 y 2] [columna 2]
            matriz.EliminarValorFil1y2Col2();//- Eliminar los valores de las [filas 1 y 2] [columna 2]
            matriz.DividirValor(total_fil1y2_col2);
            matriz.LlenarCol3_Col1y2y4();
            total_col3 = matriz.CalcTotalCol3();
            matriz.Mostrar();
        }
    }

    class Matriz
    {
        static int _cant_filas = 10,
                   _cant_columnas = 3;
        int cant_filas_actuales = 0,
            cant_columnas_actuales = 0;

        /// <summary>
        /// Dada una matriz de 10 x 3 [filas y columnas]
        /// </summary>
        private int[,] listado = new int[_cant_filas, _cant_columnas];

        #region Metodos Genericos
        /// <summary>
        /// Transladar Valor
        /// </summary>
        /// <param name="origen">fila y columna</param>
        /// <param name="destinatario">fila y columna</param>
        private void TrasladaValores(Tuple<int, int> pOrigen, Tuple<int, int> pDestinatario)
        {
            try
            {
                Console.WriteLine("Trasladar valores...");
                listado[pDestinatario.Item1 - 1, pDestinatario.Item2 - 1] = listado[pOrigen.Item1 - 1, pOrigen.Item2 - 1];
            }
            catch (Exception ex) { }
        }
        /// <summary>
        /// ObtenerValor
        /// </summary>
        /// <param name="pCelda">fila y columna</param>
        /// <returns></returns>
        private int ObtenerValor(Tuple<int, int> pCelda)
        {
            int valor = 0;
            try
            {
                valor = listado[pCelda.Item1 - 1, pCelda.Item2 - 1];
            }
            catch (Exception ex) { }
            return valor;
        }
        /// <summary>
        /// EliminarValor
        /// </summary>
        /// <param name="pCelda">fila y columna</param>
        private void EliminarValor(Tuple<int, int> pCelda)
        {
            try
            {
                listado[pCelda.Item1 - 1, pCelda.Item2 - 1] = 0;
            }
            catch (Exception ex) { }
        }
        /// <summary>
        /// AsignarValor
        /// </summary>
        /// <param name="pCelda">fila y columna</param>
        /// <param name="pValor">valor</param>
        private void AsignarValor(Tuple<int, int> pCelda, int pValor)
        {
            try
            {
                listado[pCelda.Item1 - 1, pCelda.Item2 - 1] = pValor;
            }
            catch (Exception ex) { }
        }
        #endregion

        /// <summary>
        /// Muestra el arreglo en pantalla
        /// </summary>
        public void Mostrar()
        {
            Console.WriteLine("- Mostrar la matriz con los datos");
            for (int i = 0; i < cant_filas_actuales; i++)
            {
                Console.Write("[");
                for (int j = 0; j < cant_columnas_actuales; j++)
                {
                    Console.Write(listado[i, j] + (j == cant_columnas_actuales - 1 ? "" : ","));
                }
                Console.Write("]\n");
            }
        }

        /// <summary>
        /// - Agregar datos "predeterminados" a las columnas 1 y 2
        /// </summary>
        public void Cargar()
        {
            Console.WriteLine("- Agregar datos \"predeterminados\" a las columnas 1 y 2");
            Random r = new Random();
            cant_filas_actuales = _cant_filas;
            cant_columnas_actuales = _cant_columnas;

            for (int i = 0; i < _cant_filas; i++)
            {
                listado[i, 0] = r.Next(5, 10);//1;
                listado[i, 1] = r.Next(5, 10);//1;
            }
        }

        /// <summary>
        /// - Llenar la columna 3 con la suma de las columnas 1 y 2
        /// </summary>
        public void LlenarCol3_Col1y2()
        {
            Console.WriteLine("- Llenar la columna 3 con la suma de las columnas 1 y 2");
            for (int i = 0; i < _cant_filas; i++)
            {
                listado[i, 2] = listado[i, 0] + listado[i, 1];
            }
            this.Mostrar();//temp
        }
        /// <summary>
        /// - Llenar la columna 3 con la suma de las columnas 1, 2 y 4
        /// </summary>
        public void LlenarCol3_Col1y2y4()
        {
            Console.WriteLine("- Llenar la columna 3 con la suma de las columnas 1, 2 y 4");
            for (int i = 0; i < _cant_filas; i++)
            {
                listado[i, 2] = listado[i, 0] + listado[i, 1] + listado[i, 3];
            }
            this.Mostrar();//temp
        }

        /// <summary>
        /// - Calcular el total de la columna 3 en la variable "total"
        /// </summary>
        /// <returns></returns>
        public int CalcTotalCol3()
        {
            int total = 0;
            Console.WriteLine("- Calcular el total de la columna 3 en la variable \"total\"");
            for (int i = 0; i < cant_filas_actuales; i++)
            {
                total += listado[i, 2];
            }
            Console.WriteLine("Mostrar la variable \"total\": " + total);
            return total;
        }

        /// <summary>
        /// Crear Filas y Columnas
        /// </summary>
        /// <param name="pNumFilas"></param>
        /// <param name="pNumColumnas"></param>
        public void CrearFilasyColumnas(int pNumFilas, int pNumColumnas = 0)
        {
            cant_filas_actuales = cant_filas_actuales + pNumFilas;
            cant_columnas_actuales = cant_columnas_actuales + pNumColumnas;

            Console.WriteLine("- crear dos filas (vacías)");
            int[,] nuevo_listado = new int[(cant_filas_actuales), cant_columnas_actuales];

            for (int i = 0; i < (cant_filas_actuales); i++)
            {
                for (int j = 0; j < cant_columnas_actuales; j++)
                {
                    try { nuevo_listado[i, j] = listado[i, j]; }
                    catch (Exception ex) { }
                }
            }
            listado = nuevo_listado;
            this.Mostrar();//Temp
        }

        /// <summary>
        /// - Trasladar los valores de las [filas 1 y 2] [columna 1] hacia las filas nuevas
        /// </summary>
        public void TrasladaFil1y2Col1()
        {
            Console.WriteLine("- Trasladar los valores de las [filas 1 y 2] [columna 1] hacia las filas nuevas");
            TrasladaValores(new Tuple<int, int>(1, 1), new Tuple<int, int>(11, 1));
            TrasladaValores(new Tuple<int, int>(2, 1), new Tuple<int, int>(12, 1));
            this.Mostrar(); //Temp
        }

        /// <summary>
        /// - Calcular el total de las [filas 1 y 2] [columna 2]
        /// </summary>
        /// <returns></returns>
        public int CalcTotalFil1y2Col2()
        {
            Console.WriteLine("- Calcular el total de las [filas 1 y 2] [columna 2]");
            int total = 0;
            total += this.ObtenerValor(new Tuple<int, int>(1, 2));//[fila 1] [columna 2]
            total += this.ObtenerValor(new Tuple<int, int>(2, 2));//[fila 2] [columna 2]
            Console.WriteLine("Total: " + total);
            return total;
        }

        /// <summary>
        /// - Eliminar los valores de las [filas 1 y 2] [columna 2]
        /// </summary>
        public void EliminarValorFil1y2Col2()
        {
            Console.WriteLine("- Eliminar los valores de las [filas 1 y 2] [columna 2]");
            this.EliminarValor(new Tuple<int, int>(1, 2));//[fila 1] [columna 2]
            this.EliminarValor(new Tuple<int, int>(2, 2));//[fila 2] [columna 2]
            this.Mostrar();
        }

        /// <summary>
        /// - Dividir el total del inciso anterior y colocar en partes iguales en las [filas 3 a 7][columna 4]
        /// </summary>
        public void DividirValor(int pValorAnterior)
        {
            Console.WriteLine("- Dividir el total del inciso anterior y colocar en partes iguales en las [filas 3 a 7][columna 4]");
            int resultado = pValorAnterior / 5;//Cantidad de filas
            this.AsignarValor(new Tuple<int, int>(3, 4), resultado);
            this.AsignarValor(new Tuple<int, int>(4, 4), resultado);
            this.AsignarValor(new Tuple<int, int>(5, 4), resultado);
            this.AsignarValor(new Tuple<int, int>(6, 4), resultado);
            this.AsignarValor(new Tuple<int, int>(7, 4), resultado);
            this.Mostrar();
        }
    }
}