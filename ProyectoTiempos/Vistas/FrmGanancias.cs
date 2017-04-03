using ProyectoTiempos.Utils;
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
    public partial class FrmGanancias : Form
    {
        private Logica log;
        public FrmGanancias()
        {
            InitializeComponent();
            log = new Logica();
            cbSorteo.DataSource = log.cargarComboSorteos();
        }
    }
}
