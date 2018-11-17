using System;
using System.Collections;
using System.Collections.Generic;

namespace FinalESTDAT
{
    class Program
    {
        

        Queue ColaPedido = new Queue();
        List<Queue> Pedidos = new List<Queue>();
        
       
        /// <summary>
        /// Muestra de Lista de Opciones Disponibles
        /// </summary>
        /// <returns>Opción seleccionada por el Usuario (validado)</returns>
        static int Menu()
        {
            bool convOK = false;
            string ingreso;
            int select; //pongo una variable numerica para forzar a que el Usuario ponga un numero válido
            do //El Do-While primero hace y despues pregunta, por eso, usamos esta estructura.
            {
                Console.WriteLine(
                    "****************************************************\n" +
                    "****************************************************\n" +
                    "***  *MECANICA I.F.T.S. 18 DE 02 ~ *EST DE DAT*  ***\n" +
                    "****************************************************\n" +
                    "****************************************************  ");//Título
                Console.Write(
                  "     ~ Seleccione una opcion por favor ~ " + "\n\t" +
                  "1. Crear Cola de Pedido" + "\n\t" +
                  "2. Borrar [ultima] Cola de Pedido" + "\n\t" +
                  "3. Agregar Pedido en Cola" + "\n\t" +
                  "4. Borrar Pedido" + "\n\t" +
                  "5. Listar todos los pedidos" + "\n\t" +
                  "6. Listar ultimo Pedido" + "\n\t" +
                  "7. Listar Primer Pedido" + "\n\t" +
                  "8. Cantidad de Pedidos" + "\n\t" +
                  "---------------------------------" + "\n\t" +
                  "\t" + "\n" +
                  "\t0 - Salir del Sistema");
                Console.Write("\nOpcion: ");

                ingreso = Console.ReadLine();
                convOK = Int32.TryParse(ingreso, out select);
                
                if (!convOK || select < 0 || select > 8)//Como las opciones son de 0 a 5... se entiende, no?
                {
                    LimpiarPantalla();
                    Console.WriteLine("¡Ha seleccionado una opción inválida!");
                }
            } while (!convOK || select < 0 || select > 8);/*Este pedazo de codigo se seguirá ejecutando mientras que el usuario
                                                no ingrese algo de entre 0 y 5. Fijense que la condicion
                                                es inversa. Se sigue ejecutando mientras ingrese valores menores a 0 Ó 
                                                mayores que 5.*/
            Derivador(select);
            return select;//Retornamos el valor seleccionado.
        }

        /// <summary>
        /// Validar  una expresion convirtiendola a numero, unicamente
        /// </summary>
        /// <param name="valor">Expresion a validar</param>
        /// <param name="numero">Valor convertido a numero ENTERO</param>
        /// <returns>OK de validador por si hay que resolver una accion</returns>
        static bool ValidarYLimpiar(ref string valor, out int numero)
        {
            bool conversionOK = false;
            conversionOK = Int32.TryParse(valor, out numero);
            if (!conversionOK)
            {
                LimpiarPantalla();
                Console.WriteLine("¡Ha seleccionado una opción inválida!");
                
            }
            return conversionOK;
                
        }
        /// <summary>
        /// Realiza la validacion de un numero entero evaluando si esta dentro de un rango
        /// </summary>
        /// <param name="valor">Expresion en texto</param>
        /// <param name="numero">De ser numero, el valor expresado como ENTERO</param>
        /// <param name="minimo">Valor minimo aceptable</param>
        /// <param name="maximo">Valor máximo aceptable</param>
        /// <returns>Booleano de validacion por si hay que hacer algo mas</returns>
        static bool ValidarYLimpiar(ref string valor, out int numero, int minimo, int maximo)
        {
            bool conversionOK = false;

            conversionOK = Int32.TryParse(valor, out numero);

            if (!conversionOK || numero < minimo || numero > maximo)//Como las opciones son de 0 a 5... se entiende, no?
            {
                LimpiarPantalla();
                Console.WriteLine("¡Ha seleccionado una opción inválida!");
            }
            return conversionOK;
        }


        /// <summary>
        /// Bifurcador de Funcionalidad
        /// </summary>
        /// <param name="opcion">Numero entero referido a la operacion</param>
        /// <param name="stock">Informacion de Productos con el estado actualizado.
        /// Hacemos REFERENCIA para que siempre tengamos el dato actualizado ante todo movimiento que se realice.
        /// esto lo MANTENDREMOS en todas las funciones a ejecutar (a excepción de la salida)</param>
        static void Derivador(int opcion)
        {
            /*Al finalizar la opcion ejecutada en el menu principal, el programa esperará siempre un
             valor a ingresar por teclado asi siempre muestra el resultado.*/
            LimpiarPantalla();// Primer paso, una vez que entró una opción valida es, limpio la pantalla.
            switch (opcion) //El Switch es porque puedo tener múltiples tareas a resolver
            {
                case 1:
                    //Consulta(ref stock); //Recorrerá toda la lista de productos, con y sin stock.
                    break;
                case 2:
                    //Sumar(ref stock); //Ante una compra de un producto, añadiremos unidades.
                    break;
                case 3:
                    //Resta(ref stock); //Si vendimos, sacamos unidades de circulación
                    break;
                case 4:
                    //Agregar(ref stock); //Ante la incorporación de un producto, agregamos uno a la lista
                    break;
                case 5:
                    //Quitar(ref stock);//Dejamos de vender un producto, y lo sacamos de circulación
                    break;
                case 0:
                    Console.Write("Gracias por utilizar el sistema! Saliendo...");
                    Console.ReadKey();
                    Environment.Exit(0);
                    return; //Salimos directamente :)
                default:
                    LimpiarPantalla();
                    Console.WriteLine("Opcion invalida. Reingrese una opcion");
                    opcion = -1;
                    break;
            }
            Console.Write("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        /// <summary>
        /// Solo limpia la pantalla, no hay tanto que hacer aca...
        /// </summary>
        static void LimpiarPantalla()//No hace falta explicar que carajos es...
        {
            Console.Clear();
        }

        static void Main(string[] args)
        {

            Menu();
            
        }
    }
}
