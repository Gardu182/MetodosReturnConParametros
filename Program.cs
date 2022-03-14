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
            int area, ladoBase, ladoAltura, result;
            double costoInstalacionPasto, latitud, longitud, ubicacionCancha, costoTotalInstalacion;
            double precioTransporte = 40.00;       
            bool salir = false; //Variable que nos permite saber si el usuario quiere salir o no
            while (!salir) { //Mientras el usuario no quiera salir se repite:
                try //Envolvemos el código que puede generar error en un bloque try-catch, el error puede ser que no nos de un número como opción
                {                     
                    //Opciones del menú
                    Console.WriteLine("1. Calcular Presupuesto");
                    Console.WriteLine("2. Salir");
                    Console.WriteLine("Elige una de las opciones");
                    //Convertimos a entero la opción introducida por el usuario, si ocurre un error al convertir se va al bloque catch
                    int opcion = Convert.ToInt32(Console.ReadLine());
    
                    //Estructura de control que nos permite ir a una porción u otra de código
                    //Opcion es la variable de control si coincide con una opcion entra a ese bloque de código
                    switch (opcion)
                    {
                        case 1://Si coincide con 1
                            Console.WriteLine("Favor de proporcionar la base " );
                            ladoBase = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Favor de proporcionar la altura " );
                            ladoAltura = Convert.ToInt32(Console.ReadLine());
                            area = calcularAreaCancha(ladoBase, ladoAltura);
                            Console.WriteLine("Tipo de Pasto: 1 Natural, 0 Artificial ");
                            result = Convert.ToInt16(Console.ReadLine());
                            costoInstalacionPasto = calcularCostoTotalMetroCuadrado(area, result);
                            Console.WriteLine("Favor de proporcionar su latitud ");
                            latitud = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Favor de proporcionar su longitud ");
                            longitud = Convert.ToDouble(Console.ReadLine());
                            ubicacionCancha = calcularDistancia(latitud, longitud);
                            costoTotalInstalacion = calcularCostoTotal(costoInstalacionPasto, precioTransporte, ubicacionCancha);
                            Console.WriteLine("Costo al Cliente");
                            Console.WriteLine("Precio del transporte = " + precioTransporte.ToString("C"));
                            Console.WriteLine("Precio por instalacion que es el 15% = " + (costoInstalacionPasto + ubicacionCancha * precioTransporte) * 0.15);
                            Console.WriteLine("Precio del material que es el 5% = " + (costoInstalacionPasto + ubicacionCancha * precioTransporte) * 0.05);
                            Console.WriteLine("Total a pagar " + costoTotalInstalacion.ToString("C"));
                            break;//Salimos del bloque

                        case 2:
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
        public static double calcularCostoTotalMetroCuadrado(int medidaArea, int pasto){

            double natural = 1000.00;
            double artificial = 3500.00;
            double costoInstalacion;
            double tipoPasto;

            tipoPasto = pasto == 1 ? natural: artificial;

            if(pasto == 1){

                costoInstalacion = medidaArea * tipoPasto;

            } else {

                costoInstalacion = medidaArea * tipoPasto;

            }
            
            return costoInstalacion;

        }

        public static double calcularDistancia(double lat2, double lon2){
            
            double R = 6372.795477598; //Radio de la Tierra
            double distancia;
            double lat1 = 19.3041477;
            double lon1 = -99.1068475;
            double Alat = (Math.PI/180)*((lat2) - (lat1));
            double Alon = (Math.PI/180)*((lon2) - (lon1));
            double sinLat = Math.Pow(Math.Sin(Alat/2),2);
            double sinLon = Math.Pow(Math.Sin(Alon/2),2);
            double cosLat1 = Math.Cos((Math.PI/180)*(lat1));
            double cosLat2 = Math.Cos((Math.PI/180)*(lat2));

            distancia = 2 * R * Math.Asin(Math.Sqrt(sinLat + cosLat2 * cosLat2 * sinLon));

            return distancia;

        }

        public static double calcularCostoTotal(double precioMetrocuadrado, double costoTransporte, double distancia){

            double costoTotal = precioMetrocuadrado + costoTransporte * distancia;

            return costoTotal * 0.20;

        }

    }


}