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
        private Modelo.Persona person;
        
        
        public Boolean privilegios;
        private SorteoPremiado sorPre;
        public FrmGanadores(Boolean privilegios, Modelo.Persona person)
        {
            InitializeComponent();
            notificacion = new Notificacion();
            sorPre = new SorteoPremiado();
            log = new Logica();
            sorteo = new Sorteo();
            this.privilegios = privilegios;
            
            this.person = person;
            cbSorteo.DataSource = log.cargarCombo();
        }
        public FrmGanadores()
        {
            InitializeComponent();
            notificacion = new Notificacion();
            sorPre = new SorteoPremiado();
            log = new Logica();
            sorteo = new Sorteo();

            cbSorteo.DataSource = log.cargarCombo();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            tablaGanadores.DataSource = log.CompletarTablaGanadores(cbSorteo.SelectedItem.ToString());
        }

        private void tablaGanadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (privilegios || person.id.Equals(Convert.ToInt32(this.tablaGanadores.CurrentRow.Cells[1].Value.ToString())))
                {
                    Modelo.Persona p = new Modelo.Persona();
                    int id = Convert.ToInt32(this.tablaGanadores.CurrentRow.Cells[0].Value.ToString());
                    int id_persona = Convert.ToInt32(this.tablaGanadores.CurrentRow.Cells[1].Value.ToString());
                    int id_sorteo = Convert.ToInt32(this.tablaGanadores.CurrentRow.Cells[2].Value.ToString());
                    int numero = Convert.ToInt32(this.tablaGanadores.CurrentRow.Cells[3].Value.ToString());
                    int monto_apostado = Convert.ToInt32(this.tablaGanadores.CurrentRow.Cells[4].Value.ToString());

                    p = log.BuscarPersona(id_persona);
                    double monto = log.pagarMonto(cbSorteo.SelectedItem.ToString(), numero, monto_apostado);

                    lblFelicidades.Text = "FELICIDADES";
                    lblMontoPagado.Text = monto.ToString();
                    lblNombre.Text = p.nombre + " " + p.apellido;
                }
                else
                {
                    MessageBox.Show("Problema, Vos no cuentas con Permisos para ver informacion extra.");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Problema, Intentelo Nuevamente.");
            }
           
        }
    }
}

      
    
