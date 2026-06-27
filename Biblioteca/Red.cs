using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Red
    {
        public Arbol estaciones = new Arbol();   // directorio de estaciones (ABB)

        public void AgregarEstacion(int codigo, string nombre)
        {
            Estacion e = new Estacion();
            e.codigo = codigo;
            e.nombre = nombre;
            estaciones.Insertar(e);
        }

        public Estacion ObtenerEstacion(int codigo)
        {
            return estaciones.Buscar(codigo);
        }

        // conecta dos estaciones en los dos sentidos (grafo no dirigido)
        public void Conectar(int codigoA, int codigoB, string linea)
        {
            Estacion a = estaciones.Buscar(codigoA);
            Estacion b = estaciones.Buscar(codigoB);
            if (a == null || b == null) return;

            a.conexiones.Agregar(b, linea);
            b.conexiones.Agregar(a, linea);
        }

        // devuelve todas las estaciones ordenadas por codigo (recorrido del ABB)
        public ListaRuta ListarEstaciones()
        {
            ListaRuta lista = new ListaRuta();
            estaciones.InOrden(estaciones.raiz_principal, lista);
            return lista;
        }
    }
}
