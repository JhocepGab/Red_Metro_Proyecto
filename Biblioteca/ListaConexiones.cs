namespace Biblioteca
{
    public class ListaConexiones
    {
        public NodoConexion primero = null;

        public void Agregar(Estacion destino, string linea)
        {
            Conexion c = new Conexion();
            c.destino = destino;
            c.linea = linea;

            NodoConexion nuevo = new NodoConexion();
            nuevo.dato = c;

            if (primero == null)
            {
                primero = nuevo;
            }
            else
            {
                NodoConexion aux = primero;
                while (aux.sig != null)
                {
                    aux = aux.sig;
                }
                aux.sig = nuevo;
            }
        }
    }
}