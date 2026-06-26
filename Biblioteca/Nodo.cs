using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Nodo //arbolito 
    {
        public Estacion dato;
        public Nodo izq = null;
        public Nodo der = null;
    }
    public class NodoConexion    // nodo de la lista de adyacencia
    {
        public Conexion dato;
        public NodoConexion sig = null;
    }
    public class NodoCola        // nodo de la cola (BFS)
    {
        public Estacion dato;
        public NodoCola sig = null;
    }
    public class NodoPila        // nodo de la pila (DFS)
    {
        public Estacion dato;
        public NodoPila sig = null;
    }
    public class NodoLista       // nodo de la lista enlazada (ruta)
    {
        public Estacion dato;
        public NodoLista sig = null;
    }

    public class NodoConexion    // nodo de la lista de adyacencia
    {
        public Conexion dato;
        public NodoConexion sig = null;
    }

    public class NodoRanking     // nodo de la lista ordenada (ranking)
    {
        public RegistroRuta dato;
        public NodoRanking sig = null;
    }
}
