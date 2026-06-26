using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class PilaEstaciones
    {
        public NodoPila cima = null;

        public bool EstaVacia()
        {
            return cima == null;
        }

        public void Apilar(Estacion e)
        {
            NodoPila nuevo = new NodoPila();
            nuevo.dato = e;
            nuevo.sig = cima;
            cima = nuevo;
        }

        public Estacion Desapilar()
        {
            if (cima == null) return null;

            Estacion e = cima.dato;
            cima = cima.sig;
            return e;
        }
    }
}
