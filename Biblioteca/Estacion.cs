namespace Biblioteca
{
    public class Estacion
    {
        public int codigo;
        public string nombre;
        public string zona;

        public override string ToString()
        {
            return string.Format("{0} (Zona: {1})", nombre, zona);
        }

        //el arbol (ABB) compara las estaciones por su codigo,
        //igual que Persona se compara por el dni
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