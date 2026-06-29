namespace Biblioteca
{
    public class Pila
    {
        public NodoPila cima = null;

        public bool EstaVacia()
        {
            return cima == null;
        }

        public void Apilar(Vertice v)
        {
            NodoPila nuevo = new NodoPila();
            nuevo.dato = v;
            nuevo.sig = cima;
            cima = nuevo;
        }

        public Vertice Desapilar()
        {
            if (cima == null) return null;

            Vertice v = cima.dato;
            cima = cima.sig;
            return v;
        }
    }
}