using Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Metro_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grafo g = new Grafo();
            int op = -1;

            while (op != 0)
            {
                Console.WriteLine();
                Console.WriteLine("==================================================");
                Console.WriteLine("        RED DE METRO  -  Estructura de Datos");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Ver estaciones");
                Console.WriteLine("2. Ver matriz de adyacencia");
                Console.WriteLine("3. Ver conexiones de una estacion");
                Console.WriteLine("4. Ruta con menos estaciones (BFS - cola)");
                Console.WriteLine("5. Recorrido en profundidad (DFS - pila)");
                Console.WriteLine("6. Viajar manualmente por la red");
                Console.WriteLine("7. Buscar estacion por codigo (ABB - arbol)");
                Console.WriteLine("8. Estaciones ordenadas por codigo (ABB - InOrden)");
                Console.WriteLine("0. Salir");
                Console.WriteLine("--------------------------------------------------");
                Console.Write("Elija una opcion: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.WriteLine("\n--- ESTACIONES DEL METRO ---");
                        g.MostrarEstaciones();
                        break;

                    case 2:
                        Console.WriteLine("\n--- MATRIZ DE ADYACENCIA ---");
                        g.MostrarMatriz();
                        break;

                    case 3:
                        g.VerConexiones();
                        break;

                    case 4:
                        g.BuscarRuta("BFS");
                        break;

                    case 5:
                        g.BuscarRuta("DFS");
                        break;

                    case 6:
                        g.ViajarManual();
                        break;

                    case 7:
                        g.BuscarPorCodigo();
                        break;

                    case 8:
                        Console.WriteLine("\n--- ESTACIONES ORDENADAS POR CODIGO (recorrido InOrden del arbol) ---");
                        g.MostrarOrdenadasPorCodigo();
                        break;

                    case 0:
                        Console.WriteLine("\nHasta luego!");
                        break;

                    default:
                        Console.WriteLine("\nOpcion no valida.");
                        break;
                }

                if (op != 0)
                {
                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }
    }
}
