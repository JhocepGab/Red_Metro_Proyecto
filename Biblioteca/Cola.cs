using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Cola
    {
        public NodoCola frente = null;
        public NodoCola fin = null;

        public bool EstaVacia()
        {
            return frente == null;
        }

        public void Encolar(Vertice v)
        {
            NodoCola nuevo = new NodoCola();
            nuevo.dato = v;

            if (fin == null)
            {
                frente = nuevo;
                fin = nuevo;
            }
            else
            {
                fin.sig = nuevo;
                fin = nuevo;
            }
        }

        public Vertice Desencolar()
        {
            if (frente == null) return null;

            Vertice v = frente.dato;
            frente = frente.sig;

            if (frente == null)
            {
                fin = null;
            }
            return v;
        }
    }
}
