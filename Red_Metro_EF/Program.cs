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
            int op;

            do
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("        RED DE METRO  -  Estructura de Datos");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Ver estaciones");
                Console.WriteLine("2. Ver matriz de adyacencia");
                Console.WriteLine("3. Ver conexiones de una estacion");
                Console.WriteLine("4. Ruta con menos estaciones");
                Console.WriteLine("5. Recorrido en profundidad");
                Console.WriteLine("6. Viajar manualmente por la red");
                Console.WriteLine("7. Buscar estacion por codigo");
                Console.WriteLine("8. Estaciones ordenadas por codigo");
                Console.WriteLine("9. Ruta mas rapida (menos minutos - Dijkstra)");
                Console.WriteLine("0. Salir");
                Console.WriteLine("--------------------------------------------------");
                Console.Write("Elija una opcion: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.WriteLine("\n--- ESTACIONES DEL METRO ---");
                        g.MostrarEstaciones();
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine("\n--- MATRIZ DE ADYACENCIA ---");
                        g.MostrarMatriz();
                        Console.ReadKey();
                        break;

                    case 3:
                        g.VerConexiones();
                        Console.WriteLine("\nPresione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case 4:
                        g.BuscarRuta("BFS");
                        Console.ReadKey();
                        break;

                    case 5:
                        g.BuscarRuta("DFS");
                        Console.ReadKey();
                        break;

                    case 6:
                        g.ViajarManual();
                        Console.ReadKey();
                        break;

                    case 7:
                        g.BuscarPorCodigo();
                        Console.ReadKey();
                        break;

                    case 8:
                        Console.WriteLine("\n--- ESTACIONES ORDENADAS POR CODIGO ---");
                        g.MostrarOrdenadasPorCodigo();
                        Console.ReadKey();
                        break;
                    case 9:
                        g.BuscarRuta("DIJKSTRA");
                        Console.WriteLine("\nPresione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case 0:
                        Console.WriteLine("\nHasta luego!");
                        break;

                    default:
                        Console.WriteLine("\nOpcion no valida.");
                        break;
                }
            } while (op != 0);
        }
    }
}
