using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiempos.Utils
{
    public class LogicaCasaNoPierde
    {
        private Logica log;
        private Modelo.Sorteo sor;
        private Modelo.Apuesta apu;
        private Modelo.SorteoPremiado sorPre;
        public LogicaCasaNoPierde()
        {
            log = new Logica();
            sor = new Modelo.Sorteo();
            apu = new Modelo.Apuesta();
            sorPre = new Modelo.SorteoPremiado();   
        }




    }
}
