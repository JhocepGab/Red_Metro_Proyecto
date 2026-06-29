using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Arista
    {
        public Vertice destino;
        public float peso;      //minutos que se tarda entre las dos estaciones
        //lista simple
        public Arista sig = null;
    }
}
