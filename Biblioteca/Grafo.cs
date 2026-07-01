using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Grafo
    {
        public ListaSimple l_vertices = new ListaSimple();
        public Arbol directorio = new Arbol();
        int[,] ma;
        int cantidad;

        public Grafo()
        {
            CrearEstaciones();
            cantidad = l_vertices.Contar();
            ma = new int[cantidad, cantidad];
            CrearConexiones();
        }
        void CrearEstaciones()
        {
            l_vertices.Insertar(NuevaEstacion(1, "Terminal Norte", "Norte"));
            l_vertices.Insertar(NuevaEstacion(2, "Universidad", "Norte"));
            l_vertices.Insertar(NuevaEstacion(3, "Plaza Central", "Centro"));
            l_vertices.Insertar(NuevaEstacion(4, "Mercado", "Centro"));
            l_vertices.Insertar(NuevaEstacion(5, "Hospital", "Centro"));
            l_vertices.Insertar(NuevaEstacion(6, "Estadio", "Sur"));
            l_vertices.Insertar(NuevaEstacion(7, "Museo", "Centro"));
            l_vertices.Insertar(NuevaEstacion(8, "Parque", "Sur"));
            l_vertices.Insertar(NuevaEstacion(9, "Terminal Sur", "Sur"));
            l_vertices.Insertar(NuevaEstacion(10, "Aeropuerto", "Norte"));
            l_vertices.Insertar(NuevaEstacion(11, "Catedral", "Centro"));
            l_vertices.Insertar(NuevaEstacion(12, "Playa", "Sur"));
            int[] altas = { 6, 3, 9, 1, 5, 8, 11, 2, 4, 7, 10, 12 };
            for (int i = 0; i < altas.Length; i++)
            {
                directorio.Insertar(EstacionPorCodigo(altas[i]));
            }
        }

        Estacion NuevaEstacion(int codigo, string nombre, string zona)
        {
            Estacion e = new Estacion();
            e.codigo = codigo;
            e.nombre = nombre;
            e.zona = zona;
            return e;
        }
        Estacion EstacionPorCodigo(int codigo)
        {
            Vertice temp = l_vertices.primero;
            while (temp != null)
            {
                if (temp.dato.codigo == codigo)
                {
                    return temp.dato;
                }
                temp = temp.sig;
            }
            return null;
        }

        void CrearConexiones()
        {
            Conectar("Terminal Norte", "Universidad", 4);
            Conectar("Universidad", "Plaza Central", 3);
            Conectar("Plaza Central", "Mercado", 2);
            Conectar("Mercado", "Hospital", 5);
            Conectar("Estadio", "Museo", 4);
            Conectar("Museo", "Plaza Central", 3);
            Conectar("Plaza Central", "Parque", 4);
            Conectar("Parque", "Terminal Sur", 3);
            Conectar("Aeropuerto", "Mercado", 6);
            Conectar("Mercado", "Catedral", 2);
            Conectar("Catedral", "Playa", 5);
            Conectar("Universidad", "Museo", 4);
            Conectar("Catedral", "Parque", 3);
        }
        public void Conectar(string nomA, string nomB, float minutos)
        {
            Vertice a = BuscarVertice(nomA);
            Vertice b = BuscarVertice(nomB);
            if (a == null || b == null) return;

            a.ls.Insertar(b, minutos);
            b.ls.Insertar(a, minutos);

            int ia = IndiceDe(nomA);
            int ib = IndiceDe(nomB);
            ma[ia, ib] = 1;
            ma[ib, ia] = 1;
        }
        public Vertice BuscarVertice(string nombre)
        {
            Vertice temp = l_vertices.primero;
            while (temp != null)
            {
                if (temp.dato.nombre == nombre)
                {
                    return temp;
                }
                temp = temp.sig;
            }
            return null;
        }
        public int IndiceDe(string nombre)
        {
            int i = 0;
            Vertice temp = l_vertices.primero;
            while (temp != null)
            {
                if (temp.dato.nombre == nombre)
                {
                    return i;
                }
                temp = temp.sig;
                i++;
            }
            return -1;
        }
        public Vertice ObtenerPorNumero(int numero)
        {
            int i = 1;
            Vertice temp = l_vertices.primero;
            while (temp != null)
            {
                if (i == numero)
                {
                    return temp;
                }
                temp = temp.sig;
                i++;
            }
            return null;
        }

        public Vertice GetInicio()
        {
            return l_vertices.primero;
        }
        public void MostrarEstaciones()
        {
            l_vertices.Mostrar();
        }

        public void MostrarMatriz()
        {
            for (int i = 0; i < ma.GetLength(0); i++)
            {
                for (int j = 0; j < ma.GetLength(1); j++)
                {
                    Console.Write(ma[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void MostrarConexiones(Vertice v)
        {
            v.ls.Mostrar();
        }
        public Estacion BuscarEstacion(int codigo)
        {
            return directorio.Buscar(codigo);
        }
        public void MostrarOrdenadasPorCodigo()
        {
            directorio.InOrden(directorio.raiz_principal);
        }
        public void VerConexiones()
        {
            Console.WriteLine("\n--- ESTACIONES ---");
            MostrarEstaciones();
            Console.Write("\nNumero de la estacion: ");
            int n = int.Parse(Console.ReadLine());

            Vertice v = ObtenerPorNumero(n);
            if (v == null)
            {
                Console.WriteLine("Esa estacion no existe.");
                return;
            }
            Console.WriteLine("\nConexiones de " + v.dato + ":");
            MostrarConexiones(v);
        }
        public void BuscarRuta(string metodo)
        {
            Console.WriteLine("\n--- ESTACIONES ---");
            MostrarEstaciones();
            Console.Write("\nNumero de la estacion de ORIGEN: ");
            int no = int.Parse(Console.ReadLine());
            Console.Write("Numero de la estacion de DESTINO: ");
            int nd = int.Parse(Console.ReadLine());

            Vertice origen = ObtenerPorNumero(no);
            Vertice destino = ObtenerPorNumero(nd);
            if (origen == null || destino == null)
            {
                Console.WriteLine("Alguna estacion no existe.");
                return;
            }

            float minutos = 0;
            ListaSimple ruta;
            if (metodo == "BFS")
            {
                ruta = RutaMasCorta(origen, destino, ref minutos);
            }
            else if (metodo == "DFS")
            {
                ruta = RutaEnProfundidad(origen, destino, ref minutos);
            }
            else
            {
                ruta = RutaMasRapida(origen, destino, ref minutos);
            }

            if (ruta == null)
            {
                Console.WriteLine("No hay ruta entre esas estaciones.");
                return;
            }

            Console.WriteLine("\n=== RUTA CON " + metodo + " ===");
            ruta.Mostrar();
            Console.WriteLine("Estaciones en la ruta: " + ruta.Contar());
            Console.WriteLine("Tiempo total: " + minutos + " min");
        }
        public void ViajarManual()
        {
            Console.WriteLine("\n--- VIAJE MANUAL ---");
            Console.WriteLine("Empiezas en la primera estacion y vas eligiendo a donde viajar.");
            float total = 0;
            Recorrer(GetInicio(), ref total);
            Console.WriteLine("\nTiempo total del viaje: " + total + " min");
        }
        public void BuscarPorCodigo()
        {
            Console.WriteLine("\n--- ESTACIONES (el numero es el codigo) ---");
            MostrarEstaciones();
            Console.Write("\nIngrese el codigo de la estacion a buscar: ");
            int cod = int.Parse(Console.ReadLine());

            Estacion e = BuscarEstacion(cod);
            if (e == null)
            {
                Console.WriteLine("No existe una estacion con ese codigo.");
                return;
            }
            Console.WriteLine("Encontrada (codigo " + cod + "): " + e);
        }
        void LimpiarMarcas()
        {
            Vertice temp = l_vertices.primero;
            while (temp != null)
            {
                temp.visitado = false;
                temp.anterior = null;
                temp = temp.sig;
            }
        }
        public ListaSimple RutaMasCorta(Vertice origen, Vertice destino, ref float minutos)
        {
            LimpiarMarcas();

            Cola cola = new Cola();
            origen.visitado = true;
            cola.Encolar(origen);

            bool encontrado = false;
            while (!cola.EstaVacia() && !encontrado)
            {
                Vertice actual = cola.Desencolar();

                if (actual == destino)
                {
                    encontrado = true;
                }
                else
                {
                    Arista a = actual.ls.primero;
                    while (a != null)
                    {
                        if (!a.destino.visitado)
                        {
                            a.destino.visitado = true;
                            a.destino.anterior = actual;
                            cola.Encolar(a.destino);
                        }
                        a = a.sig;
                    }
                }
            }

            if (!destino.visitado)
            {
                minutos = 0;
                return null;
            }
            return ReconstruirRuta(origen, destino, ref minutos);
        }
        public ListaSimple RutaEnProfundidad(Vertice origen, Vertice destino, ref float minutos)
        {
            LimpiarMarcas();

            Pila pila = new Pila();
            pila.Apilar(origen);

            bool encontrado = false;
            while (!pila.EstaVacia() && !encontrado)
            {
                Vertice actual = pila.Desapilar();

                if (!actual.visitado)
                {
                    actual.visitado = true;

                    if (actual == destino)
                    {
                        encontrado = true;
                    }
                    else
                    {
                        Arista a = actual.ls.primero;
                        while (a != null)
                        {
                            if (!a.destino.visitado)
                            {
                                a.destino.anterior = actual;
                                pila.Apilar(a.destino);
                            }
                            a = a.sig;
                        }
                    }
                }
            }

            if (!destino.visitado)
            {
                minutos = 0;
                return null;
            }
            return ReconstruirRuta(origen, destino, ref minutos);
        }
        public ListaSimple RutaMasRapida(Vertice origen, Vertice destino, ref float minutos)
        {
            LimpiarMarcas();
            float infinito = 1000000;
            Vertice t = l_vertices.primero;
            while (t != null)
            {
                t.distancia = infinito;
                t = t.sig;
            }
            origen.distancia = 0;

            bool termino = false;
            while (!termino)
            {
                Vertice actual = null;
                float menor = infinito;
                Vertice temp = l_vertices.primero;
                while (temp != null)
                {
                    if (!temp.visitado && temp.distancia < menor)
                    {
                        menor = temp.distancia;
                        actual = temp;
                    }
                    temp = temp.sig;
                }

                if (actual == null)
                {
                    termino = true;
                }
                else
                {
                    actual.visitado = true;
                    Arista a = actual.ls.primero;
                    while (a != null)
                    {
                        if (!a.destino.visitado)
                        {
                            float nueva = actual.distancia + a.peso;
                            if (nueva < a.destino.distancia)
                            {
                                a.destino.distancia = nueva;
                                a.destino.anterior = actual;
                            }
                        }
                        a = a.sig;
                    }
                }
            }

            if (destino.distancia >= infinito)
            {
                minutos = 0;
                return null;
            }
            return ReconstruirRuta(origen, destino, ref minutos);
        }

        ListaSimple ReconstruirRuta(Vertice origen, Vertice destino, ref float minutos)
        {
            Pila pila = new Pila();

            Vertice actual = destino;
            while (actual != null)
            {
                pila.Apilar(actual);
                if (actual == origen) break;
                actual = actual.anterior;
            }

            minutos = 0;
            ListaSimple ruta = new ListaSimple();
            Vertice previo = null;
            while (!pila.EstaVacia())
            {
                Vertice v = pila.Desapilar();
                ruta.Insertar(v.dato);
                if (previo != null)
                {
                    minutos = minutos + PesoEntre(previo, v);
                }
                previo = v;
            }
            return ruta;
        }
        float PesoEntre(Vertice a, Vertice b)
        {
            Arista temp = a.ls.primero;
            while (temp != null)
            {
                if (temp.destino == b)
                {
                    return temp.peso;
                }
                temp = temp.sig;
            }
            return 0;
        }
        public void Recorrer(Vertice v, ref float total)
        {
            Console.WriteLine("--------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Estacion actual: \n" + v.dato + "\n");
            Console.ResetColor();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Viajes disponibles: ");
            v.ls.Mostrar();
            Console.WriteLine("0. Terminar el viaje");
            Console.WriteLine("--------------------------------");
            Console.Write("Ingrese el numero de la estacion a la que desea viajar: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 0) return;

            Arista temp = v.ls.primero;
            for (int i = 1; i < op; i++)
            {
                temp = temp.sig;
            }
            total = total + temp.peso;
            Recorrer(temp.destino, ref total);
        }
    }
}
