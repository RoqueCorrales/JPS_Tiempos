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
            GananciaMaxima();
            Gananciaminima();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GananciaMaxima();
            Gananciaminima();

        }


        private void Gananciaminima()
        {
            double total = 0;
            DataTable result = new DataTable();
            Modelo.Casa casa = new Modelo.Casa();
            result = casa.SelectDineroCasa();
            double dineroCasa = Convert.ToDouble(result.Rows[0]["dinero"]);
            LogicaCasaNoPierde logCasa = new LogicaCasaNoPierde();
            string cod = cbSorteo.SelectedItem.ToString();
            int id = log.buscarID(cod);

            total = dineroCasa - logCasa.PrimerosNumerosConMasMonto(id);
            lblMinima.Text = total.ToString();
    
        }

        private void GananciaMaxima()
        {
            string cod = cbSorteo.SelectedItem.ToString();
            lblMaxima.Text = log.gananciaMaxima(cod).ToString();
        }
    }
}
