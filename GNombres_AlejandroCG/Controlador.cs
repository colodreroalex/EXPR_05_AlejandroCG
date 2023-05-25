using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNombres_AlejandroCG
{
    public static class Controlador
    {
        enum Seleccion : byte { Salir, IntroducirNombre, listarNombres, NombreAleatorio }

        public static void ControladorPrincipal()
        {
            Seleccion opcion = Seleccion.Salir;
            string nombre;
            string[] listaNombres;
            bool insertado = false; 

            //Comprobar si el fichero existe
            GFichero.ComprobarFichero();

            do
            {

                //Guardamos la opcion seleccionada en el menu principal en una variable para su posterior uso en el Switch
                opcion = (Seleccion)Interfaz.ObtenerOpcionDelMenuPrincipal((byte)Seleccion.NombreAleatorio);

                switch (opcion)
                {




                    case Seleccion.IntroducirNombre:
                        //Leemos el Nombre a introducir
                        nombre = Interfaz.LeerCadena("Introduzca el nombre que desea introducir:  ");

                        //Validamos que no sean nulos
                        //Interfaz.ValidarCadena(nombre); 

                        //Comprobamos que el nombre no este ya insertado
                        insertado = GFichero.ComprobarNombre(nombre);

                        if(!insertado)
                        {
                            //Si no lo esta, lo introduciremos en el fichero
                            GFichero.MeterNombreEnFichero(nombre);
                        }
                        
                        //Mensaje Informativo
                        Interfaz.EstaONoInsertado(insertado);
                        break;




                    case Seleccion.listarNombres:


                        //Obtenemos los nombres del fichero y los almacenamos en un array de string
                        listaNombres = GFichero.ListarNombres();

                        //Mostramos los nombres a traves de la consola por medio de la interfaz
                        Interfaz.MostrarDatosPorPantalla(listaNombres);
                        break;




                    case Seleccion.NombreAleatorio:


                        //Obtenemos un nombre al azar del fichero de txt y lo almacenamos en la variable nombre
                        nombre = GFichero.ObtenerNombreAleatorio();

                        //Mostramos cual es el nombre al azar seleccionado
                        Interfaz.MostrarNombreAleatorio(nombre);
                        break;
                }

                //Se repetira el bucle hasta que seleccionemos Salir
            } while (opcion != Seleccion.Salir);
        }
    }
}
