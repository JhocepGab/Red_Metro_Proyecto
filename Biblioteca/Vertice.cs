namespace Biblioteca
{
    public class Vertice
    {
        public Estacion dato;
        public Vertice sig = null;
        public ListaAristas ls = new ListaAristas();
        public bool visitado = false;
        public Vertice anterior = null;
    }
}