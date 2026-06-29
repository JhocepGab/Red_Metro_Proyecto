namespace Biblioteca
{
    public class Vertice
    {
        public Estacion dato;
        //lista simple
        public Vertice sig = null;

        //grafo (lista de adyacencia con las conexiones de la estacion)
        public ListaAristas ls = new ListaAristas();

        //se usan solo cuando se recorre con BFS o DFS
        public bool visitado = false;
        public Vertice anterior = null;
    }
}