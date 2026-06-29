using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Nodo
    {
        public Estacion dato;
        public Nodo izq = null;
        public Nodo der = null;
    }

    public class NodoCola
    {
        public Vertice dato;
        public NodoCola sig = null;
    }

    public class NodoPila
    {
        public Vertice dato;
        public NodoPila sig = null;
    }
}
