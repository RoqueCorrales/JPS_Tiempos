using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiempos.Utils
{
    public class Sumas
    {
        public int num { get; set; }
        public double monto { get; set; }


        public Sumas()
        {

        }


        public Sumas(int num , double monto)
        {
            this.num = num;
            this.monto = monto;
        }
    }
}
