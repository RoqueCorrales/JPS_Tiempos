using ProyectoTiempos.Controladores;
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
    public partial class FrmGanadores : Form
    {
        private Notificacion notificacion;
        private Logica log;
        private Sorteo sorteo;
        private SorteoPremiado sorPre;
        public FrmGanadores()
        {
            InitializeComponent();
            notificacion = new Notificacion();
            sorPre = new SorteoPremiado();
            log = new Logica();
            sorteo = new Sorteo();
            
            cbSorteo.DataSource = log.cargarCombo();
        }

        private void btnNotificar_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       
           
        private void cbSorteo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

      
    
