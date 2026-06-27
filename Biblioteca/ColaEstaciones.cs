using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class ColaEstaciones
    {
        public NodoCola frente = null;
        public NodoCola fin = null;

        public bool EstaVacia()
        {
            return frente == null;
        }

        public void Encolar(Estacion e)
        {
            NodoCola nuevo = new NodoCola();
            nuevo.dato = e;

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

        public Estacion Desencolar()
        {
            if (frente == null) return null;

            Estacion e = frente.dato;
            frente = frente.sig;

            if (frente == null)
            {
                fin = null;
            }
            return e;
        }
    }
}
