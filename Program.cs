///Importación de bibliotecas
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace MenuGenerico
{
    //Clase principal
    class Program
    {
        //Método main
        static void Main(string[] args)
        {             
            bool salir = false; //Variable que nos permite saber si el usuario quiere salir o no
            while (!salir) { //Mientras el usuario no quiera salir se repite:
                try //Envolvemos el código que puede generar error en un bloque try-catch, el error puede ser que no nos de un número como opción
                {                     
                    //Opciones del menú
                    Console.WriteLine("1. Calcular Presupuesto");
                    Console.WriteLine("2. Ver Desglose");
                    Console.WriteLine("3. Salir");
                    Console.WriteLine("Elige una de las opciones");
                    //Convertimos a entero la opción introducida por el usuario, si ocurre un error al convertir se va al bloque catch
                    int opcion = Convert.ToInt32(Console.ReadLine());
    
                    //Estructura de control que nos permite ir a una porción u otra de código
                    //Opcion es la variable de control si coincide con una opcion entra a ese bloque de código
                    switch (opcion)
                    {
                        case 1://Si coincide con 1
                            int area, ladoBase, ladoAltura, result;
                            double costoInstalacionPasto, latitud, longitud, ubicacionCancha;

                            Console.WriteLine("Favor de proporcionar la base " );
                            ladoBase = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Favor de proporcionar la altura " );
                            ladoAltura = Convert.ToInt32(Console.ReadLine());
                            area = calcularAreaCancha(ladoBase, ladoAltura);
                            Console.WriteLine("Tipo de Pasto: 1 Natural, 0 Artificial ");
                            result = Convert.ToInt16(Console.ReadLine());
                            costoInstalacionPasto = calcularCostoTotalMetroCuadrado(area, result);
                            Console.WriteLine("Favor de proporcionar su latitud ");
                            latitud = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Favor de proporcionar su longitud ");
                            longitud = Convert.ToInt32(Console.ReadLine());
                            ubicacionCancha = calcularDistancia(latitud, longitud);


                            Console.WriteLine("Test " + ubicacionCancha);

                            break;//Salimos del bloque
 
                        case 2://Si coincide con 2
                            Console.WriteLine("Opción 2");
                            break;

                        case 3:
                            Console.WriteLine("Hasta luego");
                            salir = true;
                            break;

                        default://Si no coincide con las opciones de 1 a 3 se ejecuta esto siempre que sea un número
                            Console.WriteLine("Opción no válida, elige una opcion entre 1 y 3");
                            break;
                    } 
                }
                catch (FormatException e)//Capturamos la excepción que pueda ocurrir
                {
                    Console.WriteLine("Formato incorrecto " + e.Message);//Mostramos el mensaje de la excepcioón
                }
            }
 
            Console.ReadLine();//Leemos un caracter para que haga una pausa antes de salir
 
        }

        public static int calcularAreaCancha(int lBase, int lAltura){
            
            return lBase * lAltura;

        }
        public static double calcularCostoTotalMetroCuadrado(int medida, int pasto){

            double natural = 1000.00;
            double artificial = 3500.00;
            double costoInstalacion;
            double tipoPasto;

            tipoPasto = pasto == 1 ? natural: artificial;

            if(pasto == 1){

                costoInstalacion = medida * tipoPasto;

            } else {

                costoInstalacion = medida * tipoPasto;

            }
            
            return costoInstalacion;

        }

        public static double calcularDistancia(double lat2, double lon2){
            
            double R = 6372.795477598; //Radio de la Tierra
            double precioTransporte = 40.00;
            double distancia;
            double lat1 = 19.3041477;
            double lon1 = -99.1068475;
            double Alat = lat2 - lat1;
            double Alon = lon2 - lon1;


            distancia = 2 * R;

            return distancia;

        }

        public void calcularCostoTotal(){

            //return ubicacionActual;

        }

    }


}