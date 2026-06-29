using System;

namespace Biblioteca
{
    public class ListaSimple
    {
        public Vertice primero = null;

        public void Insertar(Estacion d)
        {
            Vertice nuevo = new Vertice();
            nuevo.dato = d;

            if (primero == null)
            {
                primero = nuevo;
            }
            else
            {
                Vertice temp = primero;

                while (temp.sig != null)
                {
                    temp = temp.sig;
                }
                temp.sig = nuevo;
            }
        }

        public void Mostrar()
        {
            Vertice temp = primero;
            int i = 1;
            while (temp != null)
            {
                Console.WriteLine(i + ". " + temp.dato);
                temp = temp.sig;
                i++;
            }
        }

        public int Contar()
        {
            int n = 0;
            Vertice temp = primero;
            while (temp != null)
            {
                n++;
                temp = temp.sig;
            }
            return n;
        }
    }
}