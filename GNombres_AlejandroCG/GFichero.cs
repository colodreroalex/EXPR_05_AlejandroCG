using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNombres_AlejandroCG
{
    public static class GFichero
    {
        const string FICHERO = "listado.txt";

        /// <summary>
        /// METODO QUE COMPRUEBA LA EXISTENCIA DEL FICHERO
        /// </summary>
        public static void ComprobarFichero()
        {

            if (!File.Exists(FICHERO))
                File.Create(FICHERO);

        }

        /// <summary>
        /// METODO QUE METE LOS NOMBRE EN EL FICHERO
        /// </summary>
        /// <param name="nombre">NOMBRE A METER EN EL FICHERO</param>
        /// <exception cref="Exception"></exception>
        internal static void MeterNombreEnFichero(string nombre)
        {
            try
            {
                if (File.Exists(FICHERO))
                {
                    nombre = nombre.ToUpper();
                    File.AppendAllText(FICHERO, nombre + Environment.NewLine);//LO AGREGAMOS CON NUEVAS LINEAS CADA VEZ
                }
                else
                {
                    File.Create(FICHERO);
                    nombre = nombre.ToUpper();
                    File.AppendAllText(FICHERO, nombre + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ERORR" + ex.Message);
            }
        }

        /// <summary>
        /// METODO QUE LEE LOS NOMBRES DEL FICHERO 
        /// </summary>
        /// <returns>ARRAY DE STRINGS</returns>
        public static string[]? ListarNombres()
        {
            string[]? lista = null;  
            bool esCorrecto = false;
            string error = "";


            try
            {
                if (File.Exists(FICHERO))
                {
                    lista = File.ReadAllLines(FICHERO);
                    esCorrecto = true;
                }
                else
                {
                    throw new Exception($"ERROR: no se puede mostrar el listado de nombres porque el fichero {FICHERO} no existe...");
                }
            }
            catch (Exception ex)
            {
                esCorrecto = false;
                error = ex.Message;
            }


            return lista;
        }

        /// <summary>
        /// COMPROBAMOS SI EL NOMBRE YA ESTA METIDO EN EL FICHERO
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>BOOLEANO --> TRUE/FALSE </returns>
        /// <exception cref="Exception"></exception>
        internal static bool ComprobarNombre(string nombre)
        {

            bool estaInsertado = false;
            string[]? listaNombres = null ;     
            


            try
            {
                if (!File.Exists(FICHERO))
                    throw new Exception($"El fichero {FICHERO} no existe... ");
                else
                {
                    listaNombres = ListarNombres();

                    //Comprobar Duplicado
                    nombre = nombre.ToUpper();
                    for (int i = 0; i < listaNombres.Length; i++)
                    {
                        if (nombre == listaNombres[i])
                            estaInsertado = true;
                        else
                        {
                            estaInsertado = false;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }

            return estaInsertado;
        }


        /// <summary>
        /// OBTENEMOS EL NOMBRE ALEATORIO
        /// </summary>
        /// <returns>LO DEVUELVE </returns>
        public static string ObtenerNombreAleatorio()
        {
            string[] nombres = File.ReadAllLines(FICHERO);
            Random random = new Random();
            int indiceAleatorio = random.Next(0, nombres.Length);

            return nombres[indiceAleatorio];
        }
    }
}
