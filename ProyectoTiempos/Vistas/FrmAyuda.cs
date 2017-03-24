using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTiempos.Vistas
{
    public partial class FrmAyuda : Form
    {
        public FrmAyuda()
        {
            InitializeComponent();
            refrescar();
        }

       private void refrescar()
        {
            label2.Text = "La mecánica de el juego “Tiempos” consiste en lo siguiente: " + "\n" + "\n" + " Los jugadores escojen N números a los que desean apostar. "
+ "\n" + " Los números disponibles son del 0 al 99. \n Son premiados los primeros 3 números de la lotería nacional." + "\n" + "\n" +

"  El primer lugar recibe 60 veces el monto apostado " + "\n" + "\n" + " El segundo lugar recibe 10 veces el monto apostado " + "\n" + "\n" + " El tercer lugar recibe " +
"5 veces el monto apostado" + "\n" + "\n \n \n \n \n " + "Para mayor informacion escribamos a : jps.utn.ac.cr@gmail.com. ";
        }
    }
}
