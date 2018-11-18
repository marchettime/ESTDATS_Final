using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FinalESTDAT
{
    public  class Elemento : Queue
    {
        public int id;
        public string nombre;
        public int cantidad;
    }

    public class PedidoXCliente
    {
        public string nombreCliente;
        public Queue<Elemento> Pedidos = new Queue<Elemento>();
    }
    

    class Program
    {
        public static string ingresoOpcion = "";
        public static List<PedidoXCliente> ListaDePedidos = new List<PedidoXCliente>();
        public static PedidoXCliente TrabajandoActualmente = new PedidoXCliente();      
        
        /// <summary>
        /// Muestra de Lista de Opciones Disponibles
        /// </summary>
        /// <returns>Opción seleccionada por el Usuario (validado)</returns>
        public static void Menu()
        {
            bool convOK = false;
            int select; //pongo una variable numerica para forzar a que el Usuario ponga un numero válido
            do //El Do-While primero hace y despues pregunta, por eso, usamos esta estructura.
            {
                Console.WriteLine(
                    "*******************************************\n" +
                    "*******************************************\n" +
                    "***  *I.F.T.S. 18 DE 02 ~ *EST DE DAT*  ***\n" +
                    "*******************************************\n" +
                    "*******************************************  ");//Título
                if (TrabajandoActualmente.nombreCliente != null && TrabajandoActualmente.nombreCliente != "")
                {
                    Console.WriteLine("\n Usted está trabajando actualmente con el cliente: {0}", TrabajandoActualmente.nombreCliente);
                }
                Console.Write(
                  "     ~ Seleccione una opcion por favor ~ " + "\n\t" +
                  "1. Crear nueva Cola de Pedido" + "\n\t" +
                  "2. Agregar Pedido a la Cola" + "\n\t" +
                  "\n\t" +
                  "3. Borrar ultimo Elemento en Cola" + "\n\t" +
                  "4. Borrar TODA la Cola de Pedido" + "\n\t" +
                  "\n\t" +
                  "5. Mostrar Cola sin Registrar en Lista" + "\n\t" +
                  "\n\t" +
                  "6. Ingresar Cola a LISTA" + "\n\t" + //Pasa de Cola a la Lista NUEVA OPCION PEDIDA
                  "\n\t" +
                  "7. LISTAR TODOS los Pedidos en la Lista" + "\n\t" +
                  "8. LISTAR Primer Pedido en la Lista" + "\n\t" +
                  "9. LISTAR ULTIMO Pedido en la Lista" + "\n\t" +
                  "10. Cantidad de Pedidos" + "\n\t" +
                  "-----------NUEVAS----------------" + "\n\t" +

                  "11. Buscar Cliente" + "\n\t" +


                  "---------------------------------" + "\n\t" +
                  "\t" + "\n" +
                  "\tX - Salir del Sistema");
                // Cerrar con "X" y asi dejar el 0 utilizable

                Console.Write("\nOpcion: ");

                ingresoOpcion = Console.ReadLine();
                if (ingresoOpcion.ToUpper() == "X")
                {
                    LimpiarPantalla();
                    Console.Write("Gracias por utilizar el sistema! Saliendo...");
                    EsperarTecla();
                    Environment.Exit(0);
                    return; //Salimos directamente :)
                }
                convOK = ValidarYLimpiar(ref ingresoOpcion, out select, 0, 11);
                if(convOK)
                    Derivador(select);
            } while (!convOK);
            
        }

        /// <summary>
        /// Validar  una expresion convirtiendola a numero, unicamente
        /// </summary>
        /// <param name="valor">Expresion a validar</param>
        /// <param name="numero">Valor convertido a numero ENTERO</param>
        /// <returns>OK de validador por si hay que resolver una accion</returns>
        public static bool ValidarYLimpiar(ref string valor, out int numero)
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
        public static bool ValidarYLimpiar(ref string valor, out int numero, int minimo, int maximo)
        {
            bool conversionOK = false;

            conversionOK = Int32.TryParse(valor, out numero);

            if (!conversionOK || (conversionOK && (numero < minimo || numero > maximo) ))//Como las opciones son de 0 a 5... se entiende, no?
            {
                conversionOK = false; //se fuerza por el rango de numeros
                LimpiarPantalla();
                Console.WriteLine("¡Ha ingresado un valor inválido!");
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
        public static void Derivador(int opcion)
        {
            /*Al finalizar la opcion ejecutada en el menu principal, el programa esperará siempre un
             valor a ingresar por teclado asi siempre muestra el resultado.*/
            LimpiarPantalla();// Primer paso, una vez que entró una opción valida es, limpio la pantalla.
            switch (opcion) //El Switch es porque puedo tener múltiples tareas a resolver
            {
                case 1:
                    //Crear Cola
                    CrearCola();
                    break;
                case 2:
                    AgregarElemento();
                    break;
                case 3:
                    BorrarElementoEnCola();
                    break;
                case 4:
                    BorrarCola();
                    break;
                case 5:
                    MostrarColaActual();
                    break;
                case 6:
                    PedidoALista();
                    break;
                case 7:
                    MostrarTodosLosPedidos();
                    break;
                case 8:
                    MostrarPrimerElementoDeLista();
                    break;
                case 9:
                    MostrarUltimoElementoDeLista();
                    break;
                case 10:
                    CantidadDePedidos();
                    break;
                case 11:
                    BuscarCliente();
                    break;
                
                default:
                    Console.WriteLine("No se encuentra la opcion seleccionada!");
                    Menu();
                    break;
            }

            LimpiarPantalla();

        }

        /// <summary>
        /// Crea una Cola en la que debera ponerse CLIENTE y Productos a informar
        /// </summary>
        public static void CrearCola()
        {
            //PedidoXCliente ColaPedido = new PedidoXCliente();
            //Elemento articulo = new Elemento();
            string rescate;
            int decision;
            if (TrabajandoActualmente.nombreCliente != null && TrabajandoActualmente.nombreCliente !="")
            {
                do
                {
                    Console.WriteLine("Hay datos sin resguardar en la lista. ¿Descartarlos?\n1: Guardar | 2: Descartar datos");
                    rescate = Console.ReadLine();
                    ValidarYLimpiar(ref rescate, out decision, 1, 2);
                } while (decision != 1 && decision != 2);
                if (decision == 1)
                    PedidoALista();
                else
                    BorrarCola();
            }
            string ingresoTeclado;
            do
            {
                Console.Write("Ingrese nombre del Cliente: ");
                ingresoTeclado = Console.ReadLine();
            } while (ingresoTeclado == "" || ingresoTeclado == null);
            //ColaPedido.nombreCliente = ingresoTeclado;
            TrabajandoActualmente.nombreCliente = ingresoTeclado;
            TrabajandoActualmente.Pedidos.Clear();
            Console.WriteLine("Se ha generado un Nuevo Cliente: {0}\n Se sugiere agregar elementos a su pedido...", TrabajandoActualmente.nombreCliente);
            EsperarTecla();
            
        }

        /// <summary>
        /// Da de alta un valor en la cola del pedido del Cliente
        /// </summary>
        public static void AgregarElemento()
        {
            Elemento nuevoElemento = new Elemento();
            string ingresoTeclado;
            bool Validador;
            do {
                Console.WriteLine("****Agregado de Elemento a Cola****");
                Console.Write("Ingrese el Codigo de Elemento: ");
                ingresoTeclado = Console.ReadLine();
                Console.WriteLine("");
                Validador = ValidarYLimpiar(ref ingresoTeclado, out nuevoElemento.id, 0, 999);
            } while (!Validador);

            do
            {
                Console.Write("Ingrese el Nombre del Elemento (no puede ser vacío): ");
                ingresoTeclado = Console.ReadLine();
                Console.WriteLine("");
            } while (ingresoTeclado.Equals(""));
            nuevoElemento.nombre = ingresoTeclado;

            Console.WriteLine("¿Compraste Unidades? Si ingresas \'S\' podras sumar unidades!");
            Console.Write("Opcion: ");
            ingresoTeclado = Console.ReadLine();
            Console.WriteLine();
            if (ingresoTeclado.Length == 1 && ingresoTeclado.ToUpper() == "S")
            {
                do
                {
                    Console.Write("Unidades Compradas: ");
                    ingresoTeclado = Console.ReadLine();
                    Console.WriteLine("");
                    Validador = ValidarYLimpiar(ref ingresoTeclado, out nuevoElemento.cantidad, 0, Int32.MaxValue);
                } while (!Validador);
            }
            else
                nuevoElemento.cantidad = 0;

            //Console.WriteLine("Pedido a Agregar: ");
            Console.Write("\n ID de Elemento: {0}"
                 + "\t| Nombre de Elemento: {1}"
                 + "\t| Unidades: {2}",nuevoElemento.id, nuevoElemento.nombre,  nuevoElemento.cantidad
                );
            //Console.WriteLine("\nS: Confirmar | N: Cancelar sin guardar");
            //Console.Write("Opcion; ");
            //ingresoTeclado = Console.ReadLine();
            //Console.WriteLine();
            //if (ingresoTeclado.Length == 1 && ingresoTeclado.ToUpper() == "S")
            //{
                TrabajandoActualmente.Pedidos.Enqueue(nuevoElemento);
                Console.WriteLine("PEDIDO AGREGADO CON EXITO");
            //}
            //else
            //    Console.WriteLine("No se han aplicado cambios");
            //
            EsperarTecla();

        }

        /// <summary>
        /// Borrado absoluto de la cola
        /// </summary>
        public static void BorrarCola()
        {
            string ingresoTeclado;
            Console.WriteLine("******BORRADO DE COLA******");
            if (TrabajandoActualmente.Pedidos.Count != 0)
            {
                MostrarColaActual();
                Console.Write("Esta seguro que desea borrar esta cola? Si ingresas \'S\' podras sumar unidades.");
                ingresoTeclado = Console.ReadLine();
                if (ingresoTeclado.Length == 1 && ingresoTeclado == "S")
                {
                    TrabajandoActualmente.Pedidos.Clear();
                }
                else
                {
                    Console.WriteLine("******NO SE HAN REALIZADO MODIFICACIONES******");
                }
            }
            else
                Console.WriteLine("No hay elementos por borrar");
            EsperarTecla();

        }

        /// <summary>
        /// Borra elemento en cola
        /// </summary>
        public static void BorrarElementoEnCola()
        {
            if (TrabajandoActualmente.Pedidos.Count != 0)
            {
                string ingresoTeclado;
                Console.WriteLine("******BORRADO DE ELEMENTO EN COLA******");
                Elemento muestra = new Elemento();
                muestra = TrabajandoActualmente.Pedidos.Peek();
                Console.Write("¿Esta seguro que desea borrar esta cola?");
                Console.WriteLine("\nID de Elemento: {0}"
                     + "\t| Nombre de Elemento: {1}"
                     + "\t| Unidades: {2}", muestra.id, muestra.nombre, muestra.cantidad);

                Console.WriteLine("\nS: Confirmar | N: Cancelar sin guardar");                
                ingresoTeclado = Console.ReadLine();
                if (ingresoTeclado.Length == 1 && ingresoTeclado.ToUpper() == "S")
                {
                    TrabajandoActualmente.Pedidos.Dequeue();
                    Console.WriteLine("PEDIDO QUITADO CON EXITO");
                }
                else
                {
                    Console.WriteLine("******NO SE HAN REALIZADO MODIFICACIONES******");
                }
            }
            else
            {
                Console.WriteLine("No hay elementos en la Cola!");
            }
            EsperarTecla();

        }

        /// <summary>
        /// El elemento "TrabajandoActualmente" es agregado a la lista, y se deja disponibilizada una nueva Cola para trabajar
        /// </summary>
        public static void PedidoALista()
        {
            if(TrabajandoActualmente.Pedidos.Count != 0)
            {
                PedidoXCliente agregar = new PedidoXCliente();
                agregar.nombreCliente = TrabajandoActualmente.nombreCliente;
                agregar.Pedidos = new Queue<Elemento>(TrabajandoActualmente.Pedidos);
                ListaDePedidos.Add(agregar);
                Console.WriteLine("Se ha agregado el Pedido del cliente: {0} a la Lista!", TrabajandoActualmente.nombreCliente);
                TrabajandoActualmente.nombreCliente = null;
                TrabajandoActualmente.Pedidos.Clear();
            }
            else
            {
                Console.WriteLine("No hay elementos en la Cola!");
            }
            EsperarTecla();
            

        }

        /// <summary>
        /// Clava la pantalla esperando una tecla para avanzar, nada mas. Para no andar repitiendo codigo.
        /// </summary>
        public static void EsperarTecla()
        {
            Console.Write("\n\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        /// <summary>
        /// Solo limpia la pantalla, no hay tanto que hacer aca...
        /// </summary>
        public static void LimpiarPantalla()
        {
            Console.Clear();
        }

        /// <summary>
        /// Muestra el estado actual de la Cola :)
        /// </summary>
        public static void MostrarColaActual()
        {
            Console.Write("CLIENTE: {0}", TrabajandoActualmente.nombreCliente);
            Queue<Elemento> colaElementos = new Queue<Elemento>(TrabajandoActualmente.Pedidos);
            Elemento muestra = new Elemento();
            if (colaElementos.Count == 0)
            {
                Console.WriteLine("Este cliente no tiene elementos registrados");
            }
            else
            {
                
                //Si no me muevo con lo que estoy trabajando y luego no lo reasigno puedo estar en problemas.
                while (colaElementos.Count > 0)
                {
                    muestra = colaElementos.Dequeue();
                    Console.WriteLine("\nID de Elemento: {0}"
                     + "\t| Nombre de Elemento: {1}"
                     + "\t| Unidades: {2}", muestra.id, muestra.nombre, muestra.cantidad);
                    
                }
            }
            EsperarTecla();
        }

        /// <summary>
        /// Imprime toda la Lista de Clientes y pedidos si es que hay
        /// </summary>
        public static void MostrarTodosLosPedidos()
        {
            if (ConsultarSiElementosEnLista())
            {
                //hay que encolar y desencolar para ponver todo en su lugar
            
                
                foreach (PedidoXCliente pedidoDeCliente in ListaDePedidos)
                {
                    Queue<Elemento> CopiaDeElementos = new Queue<Elemento>(pedidoDeCliente.Pedidos);
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("---CLIENTE:---{0}---", pedidoDeCliente.nombreCliente);
                    Console.WriteLine("---------------------------------------------------");
                    //Hago una copia para no borrar ni tocar el original!
                    if (pedidoDeCliente.Pedidos.Count != 0)
                    {
                        
                        while (CopiaDeElementos.Count > 0)
                        {
                            Elemento muestra = CopiaDeElementos.Dequeue();//Desencolo y lo meto en una muestra para poder imprimir
                            Console.WriteLine("\nID de Elemento: {0}"
                             + "\t| Nombre de Elemento: {1}"
                             + "\t| Unidades: {2}", muestra.id, muestra.nombre, muestra.cantidad);
                        }
                    }
                    else {
                        Console.WriteLine("------NO TIENE PEDIDOS PARA MOSTRAR!!!-------------");
                    }
                }
                Console.WriteLine("_________FIN DE REPORTE_________");
            }
           
            EsperarTecla();
        }

        /// <summary>
        /// Muestra si es que hay un ultimo elemento de lista
        /// </summary>
        public static void MostrarUltimoElementoDeLista()
        {
            if (ConsultarSiElementosEnLista())
            {
                PedidoXCliente registro = ListaDePedidos.Last();
                Queue<Elemento> CopiaDeElementos = new Queue<Elemento>(registro.Pedidos);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("---CLIENTE:---{0}---", registro.nombreCliente);
                Console.WriteLine("---------------------------------------------------");
                //Hago una copia para no borrar ni tocar el original!
                if (registro.Pedidos.Count != 0)
                {
                    
                    while (CopiaDeElementos.Count > 0)
                    {
                        Elemento muestra = CopiaDeElementos.Dequeue();//Desencolo y lo meto en una muestra para poder imprimir
                        Console.WriteLine("\nID de Elemento: {0}"
                         + "\t| Nombre de Elemento: {1}"
                         + "\t| Unidades: {2}", muestra.id, muestra.nombre, muestra.cantidad);
                    }
                }
                else
                {
                    Console.WriteLine("------NO TIENE PEDIDOS PARA MOSTRAR!!!-------------");
                }
            }
            EsperarTecla();
        }

        /// <summary>
        ///  Muestra si es que hay un primer elemento de lista
        /// </summary>
        public static void MostrarPrimerElementoDeLista()
        {
            if (ConsultarSiElementosEnLista())
            {
                PedidoXCliente registro = ListaDePedidos.First();
                Queue<Elemento> CopiaDeElementos = new Queue<Elemento>(registro.Pedidos);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("---CLIENTE:---{0}---", registro.nombreCliente);
                Console.WriteLine("---------------------------------------------------");
                //Hago una copia para no borrar ni tocar el original!
                if (registro.Pedidos.Count != 0)
                {
                    
                    while (CopiaDeElementos.Count > 0)
                    {
                        Elemento muestra = CopiaDeElementos.Dequeue();//Desencolo y lo meto en una muestra para poder imprimir
                        Console.WriteLine("\nID de Elemento: {0}"
                         + "\t| Nombre de Elemento: {1}"
                         + "\t| Unidades: {2}", muestra.id, muestra.nombre, muestra.cantidad);
                    }
                }
                else
                {
                    Console.WriteLine("------NO TIENE PEDIDOS PARA MOSTRAR!!!-------------");
                }
            }
            EsperarTecla();
        }

        /// <summary>
        /// Cuenta clientes y lineas de elementos ingresadas
        /// </summary>
        public static void CantidadDePedidos()
        {
            int cantidadClientes = 0, cantidadElementosPedidos = 0;
            if (ConsultarSiElementosEnLista())
            {
                foreach (PedidoXCliente registroDeCliente in ListaDePedidos)
                {
                    cantidadClientes++;
                    cantidadElementosPedidos = cantidadElementosPedidos + registroDeCliente.Pedidos.Count; 
                }
                Console.WriteLine("Clientes: {0} | Pedidos: {1}", cantidadClientes, cantidadElementosPedidos);
            }
            EsperarTecla();
        }

        /// <summary>
        /// nos devela si hay elementos ya guardados en la lista... Si no hay pasa.
        /// </summary>
        /// <returns>True si hay al menos un valor | False si esta vacío.</returns>
        public static bool ConsultarSiElementosEnLista()
        {
            if (ListaDePedidos.Count == 0)
            {
                Console.WriteLine("LO SENTIMOS. NO HEMOS ENCONTRADO ELEMENTOS EN LISTA");
                return false;
            }
            else
                return true;
        }

        public static void BuscarCliente()
       {
            if (ConsultarSiElementosEnLista())
            { 
                string ingresoTeclado;
                Console.Write("Cliente a Buscar: ");
                ingresoTeclado = Console.ReadLine();
                bool flagEncuentro = false;
                foreach (PedidoXCliente registro in ListaDePedidos)
                {
                    if (Equals(ingresoTeclado.ToUpper(),registro.nombreCliente.ToUpper()))
                    {
                        flagEncuentro = true;
                        Queue<Elemento> CopiaDeElementos = new Queue<Elemento>(registro.Pedidos);
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("---CLIENTE:---{0}---", registro.nombreCliente);
                        Console.WriteLine("---------------------------------------------------");
                        //Hago una copia para no borrar ni tocar el original!
                        if (registro.Pedidos.Count != 0)
                        {
                            CopiaDeElementos = registro.Pedidos;
                            while (CopiaDeElementos.Count > 0)
                            {
                                Elemento muestra = CopiaDeElementos.Dequeue();//Desencolo y lo meto en una muestra para poder imprimir
                                Console.WriteLine("\nID de Elemento: {0}"
                                 + "\t| Nombre de Elemento: {1}"
                                 + "\t| Unidades: {2}", muestra.id, muestra.nombre, muestra.cantidad);
                            }
                        }
                        else
                        {
                            Console.WriteLine("------NO TIENE PEDIDOS PARA MOSTRAR!!!-------------");
                        }
                    }
                }
                if (!flagEncuentro)
                {
                    Console.WriteLine("No se han encontrado coincidencias de Clientes");
                }
            }
            EsperarTecla();
        }

        public static void Main(string[] args)
        {
            do
            {
                Menu();
            } while (ingresoOpcion != "0");
        }
    }
}
