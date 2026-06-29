using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Arbol
    {
        public Nodo raiz_principal = null;

        public void Insertar(Estacion e)
        {
            InsertarRecursivo(ref raiz_principal, e);
        }
        public void InsertarRecursivo(ref Nodo raiz, Estacion e)
        {
            if (raiz == null)
            {
                Nodo nuevo = new Nodo();
                nuevo.dato = e;
                raiz = nuevo;
            }
            else
            {
                if (e < raiz.dato)
                {
                    InsertarRecursivo(ref raiz.izq, e);
                }
                else if (e > raiz.dato)
                {
                    InsertarRecursivo(ref raiz.der, e);
                }
            }
        }

        public Estacion Buscar(int codigo)
        {
            Estacion e = new Estacion();
            e.codigo = codigo;
            return BuscarRecursivo(raiz_principal, e);
        }
        public Estacion BuscarRecursivo(Nodo raiz, Estacion e)
        {
            if (raiz == null)
            {
                return null;
            }
            else
            {
                if (e < raiz.dato)
                {
                    return BuscarRecursivo(raiz.izq, e);
                }
                else if (e > raiz.dato)
                {
                    return BuscarRecursivo(raiz.der, e);
                }
                else
                {
                    return raiz.dato;
                }
            }
        }
        public void InOrden(Nodo raiz)
        {
            if (raiz != null)
            {
                InOrden(raiz.izq);
                Console.WriteLine(raiz.dato);
                InOrden(raiz.der);
            }
        }
    }
}
