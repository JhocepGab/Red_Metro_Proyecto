using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class ListaRuta
    {
        public NodoLista primero = null;
        public NodoLista ultimo = null;

        public void Agregar(Estacion e)
        {
            NodoLista nuevo = new NodoLista();
            nuevo.dato = e;

            if (primero == null)
            {
                primero = nuevo;
                ultimo = nuevo;
            }
            else
            {
                ultimo.sig = nuevo;
                ultimo = nuevo;
            }
        }

        public bool EstaVacia()
        {
            return primero == null;
        }

        public int Contar()
        {
            int n = 0;
            NodoLista aux = primero;
            while (aux != null)
            {
                n++;
                aux = aux.sig;
            }
            return n;
        }
    }
}
