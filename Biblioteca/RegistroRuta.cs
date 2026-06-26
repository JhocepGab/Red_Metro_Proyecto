namespace Biblioteca
{
    public class RegistroRuta
    {
        public string origen;
        public string destino;
        public string metodo;
        public int cantidad;   // cuantas estaciones tiene la ruta

        public override string ToString()
        {
            return string.Format("{0} -> {1}  |  {2}  |  {3} estaciones",
                                  origen, destino, metodo, cantidad);
        }

        // la lista ordenada compara por la cantidad de estaciones
        public static bool operator >(RegistroRuta r1, RegistroRuta r2)
        {
            if (r1.cantidad > r2.cantidad) return true;
            return false;
        }
        public static bool operator <(RegistroRuta r1, RegistroRuta r2)
        {
            if (r1.cantidad < r2.cantidad) return true;
            return false;
        }
    }
}