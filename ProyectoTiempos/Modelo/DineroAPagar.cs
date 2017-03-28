using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiempos.Modelo
{
   public class DineroAPagar
    {
        public int id_sorteo;
        public int numero;
        public double monto;


        public DineroAPagar()
        {
                
        }

        public DineroAPagar(int id_sorteo , int numero , double monto)
        {
            this.id_sorteo = id_sorteo;
            this.numero = numero;
            this.monto = monto;
        }
    }
}
