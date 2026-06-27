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
                // si es igual no se hace nada (codigo repetido)
            }
        }

        public Estacion Buscar(int codigo)
        {
            Estacion buscada = new Estacion();
            buscada.codigo = codigo;
            return BuscarRecursivo(raiz_principal, buscada);
        }
        public Estacion BuscarRecursivo(Nodo raiz, Estacion e)
        {
            if (raiz == null) return null;

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

        // recorre en orden y va metiendo las estaciones en la lista
        public void InOrden(Nodo raiz, ListaRuta lista)
        {
            if (raiz != null)
            {
                InOrden(raiz.izq, lista);
                lista.Agregar(raiz.dato);
                InOrden(raiz.der, lista);
            }
        }
    }
}
