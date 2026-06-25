namespace Biblioteca
{
    public class Estacion
    {
        public int codigo;
        public string nombre;
        public ListaConexiones conexiones = new ListaConexiones();
        public bool visitada = false;
        public Estacion anterior = null;

        public override string ToString()
        {
            return string.Format("[{0}] {1}", codigo, nombre);
        }

        //compara las estaciones por su codigo
        public static bool operator >(Estacion e1, Estacion e2)
        {
            if (e1.codigo > e2.codigo) return true;
            return false;
        }
        public static bool operator <(Estacion e1, Estacion e2)
        {
            if (e1.codigo < e2.codigo) return true;
            return false;
        }
    }
}