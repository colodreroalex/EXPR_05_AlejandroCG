using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNombres_AlejandroCG
{
    public static class Interfaz
    {
        /// <summary>
        /// METODO VOID QUE MUESTRA LAS OPCIONES DEL MENU PRINCIPAL
        /// </summary>
        public static void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("=======================================================");
            Console.WriteLine("                                                       *");
            Console.WriteLine("\t0.- Salir                                      *");
            Console.WriteLine("\t1.- Introducir un nombre                       *");
            Console.WriteLine("\t2.- Listar Nombres del fichero                 *");
            Console.WriteLine("\t3.- Obtener Nombre Aleatorio del fichero       *");
            Console.WriteLine("                                                       *");
            Console.WriteLine("=======================================================");

        }

        /// <summary>
        /// METODO QUE REVUELVE LA OPCION ESCOGIDA DEL MENU PRINCIPAL
        /// </summary>
        /// <param name="opMax">Parametro Maximo de Opcion</param>
        /// <returns>OPCION DEL MENU</returns>
        /// <exception cref="Exception"></exception>
        internal static int ObtenerOpcionDelMenuPrincipal(byte opMax)
        {
            int opcion = 0;
            bool esCorrecto = false;

            MostrarMenuPrincipal();

            try
            {
                opcion = LeerOpcion(opMax);
                esCorrecto = true;
            }
            catch (Exception ex)
            {

                throw new Exception( ex.Message);
            }

            return opcion;
        }

        /// <summary>
        /// LEE UNA OPCION Y LA DEVUELVE
        /// </summary>
        /// <param name="opMax">Opcion Maxima</param>
        /// <returns>OPCION ESCOGIDA</returns>
        public static int LeerOpcion(byte opMax)
        {
            int opcion = 0;
            Console.Write("\n\tElija una opcion:  ");
            opcion = Convert.ToInt32(Console.ReadLine());

            return opcion;

        }

        /// <summary>
        /// LEE UNA CADENA DE TEXTO
        /// </summary>
        /// <param name="msj">MENSAJE A INTRODUCIR PERSONALIZADO</param>
        /// <returns>CADENA DE TEXTO</returns>
        internal static string LeerCadena(string msj)
        {
            Console.Clear();
            string nombre;
            
            Console.WriteLine(msj);
            nombre = Console.ReadLine();

            
            return nombre;
        }

        /// <summary>
        /// METODO SIMPLE PARA VALIDAR QUE NO SE INTRODUZCAN NOMBRES NULOS O QUE NO SE INTRODUZCAN 
        /// </summary>
        /// <param name="nombre">NOMBRE A VALIDAR</param>
        /// <exception cref="Exception"></exception>
        internal static void ValidarCadena(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) throw new Exception("No has introducido ningun nombre..");
            if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("Hay espacios en blanco o es nulo..");
        }

        /// <summary>
        /// MOSTRAMOS LOS NOMBRES OBTENIDOS DEL FICHERO ANTERIORMENTE 
        /// </summary>
        /// <param name="listaNombre">LA LISTA DE LOS NOMBRES A MOSTRAR</param>
        internal static void MostrarDatosPorPantalla(string[] listaNombre)
        {
            Console.Clear(); 
            Console.WriteLine(String.Join(Environment.NewLine, listaNombre)); //--> String.Join : Une los elementos en una cadena y
                                                                              //te los separa por nuevas lineas como su nombre indica ( propiedad newline )  
            Console.WriteLine("\nPulse ENTER para continuar...");
            Console.ReadLine(); 
            
        }
        
        /// <summary>
        /// METODO QUE ESPECIFICA SI ESTA EL NOMBRE INSERTADO O NO
        /// </summary>
        /// <param name="insertado">BOOLEANO QUE DETERMINA SI ESTA INSERTADO O NO</param>
        internal static void EstaONoInsertado(bool insertado)
        {

            
            if (insertado == true)
            {
                Console.WriteLine("El nombre esta insertado ya en el archivo...");
                Console.WriteLine("Pulsa ENTER para continuar ");
                Console.ReadLine();
                Console.Clear(); 
            }
            else
            {
                Console.WriteLine("El nombre se ha añadido exitosamente!");
                Console.WriteLine("Pulsa ENTER para continuar ");
                Console.ReadLine();
                Console.Clear();
                
                
            }
        }

        /// <summary>
        /// METODO QUE MUESTRA POR PANTALLA EL NOMBRE ALEATORIO OBTENIDO
        /// </summary>
        /// <param name="nombre"></param>
        internal static void MostrarNombreAleatorio(string nombre)
        {
            Console.Clear(); 
            Console.WriteLine($"El nombre obtenido aleatoriomente es --> {nombre}");
            Console.WriteLine("Pulse ENTER para continuar... ");
            Console.ReadLine(); 
            
        }
    }
}
