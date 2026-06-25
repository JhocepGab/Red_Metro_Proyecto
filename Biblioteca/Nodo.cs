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

}
