using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoTiempos.Vistas;
using ProyectoTiempos.Controladores;
using System.Timers;
using System.Diagnostics;

namespace ProyectoTiempos
{

    public partial class FrmPrincipal : Form
    {

        private FrmConfigCasa oConfigCasa;
        private FrmGanancias oGanancias;
        private FrmGanadores oGanadores;
        private FrmNumerosPremiados oPremiados;
        private FrmCrearSorteo oSorteos;
        private FrmAyuda oAyuda;
        private FrmVerSorteos oVerSorteos;
        private FrmJugar oJugar;
        private Modelo.Persona person;
        private Sorteo sorteo;
        public Utils.Logica log;
        public Boolean privilegios;

        public FrmPrincipal()
        
        {
            InitializeComponent();

        }
        public FrmPrincipal(Boolean privilegios , Modelo.Persona person)
        {
            InitializeComponent();
            this.privilegios = privilegios;
            configuracion.Visible = privilegios;
            this.person = person;
            lblJugador.Text = person.nombre + " " + person.apellido;
            log = new Utils.Logica();
            sorteo = new Sorteo();
            sorteosVencidos();
        }

        private bool HandleForm(Form currentForm)
        {
            if (this.MdiChildren.Contains(currentForm))
            {
                currentForm.WindowState = FormWindowState.Maximized;
                currentForm.Activate();
                return false;
            }
            return true;
        }
        private void configuracionDElaCasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.HandleForm(this.oConfigCasa))
            {
                this.oConfigCasa = new FrmConfigCasa();
                oConfigCasa.MdiParent = this;
                oConfigCasa.Show();
            }
        }

        private void tablaDeGanadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.HandleForm(this.oGanadores))
            {
                this.oGanadores = new FrmGanadores(privilegios,person);
                oGanadores.MdiParent = this;
                oGanadores.Show();
            }
        }

        private void numerosPremiadosEnSorteoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.HandleForm(this.oPremiados))
            {
                this.oPremiados = new FrmNumerosPremiados();
                oPremiados.MdiParent = this;
                oPremiados.Show();
            }
        }



        private void crearSorteoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.HandleForm(this.oSorteos))
            {
                this.oSorteos = new FrmCrearSorteo();
                oSorteos.MdiParent = this;
                oSorteos.Show();
            }

        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.HandleForm(this.oAyuda))
            {
                this.oAyuda = new FrmAyuda();
                oAyuda.MdiParent = this;
                oAyuda.Show();
            }
        }

        private void disponiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.HandleForm(this.oVerSorteos))
            {
                this.oVerSorteos = new FrmVerSorteos();
                oVerSorteos.MdiParent = this;
                oVerSorteos.Show();
            }
        }

        private void jugarToolStripMenuItem_Click(object sender, EventArgs e)

        {
            if (this.HandleForm(this.oJugar))
            {
                this.oJugar = new FrmJugar(person);
                oJugar.MdiParent = this;
                oJugar.Show();
            }
        }


        private void sorteosVencidos()
        {
            int cont = 0;
            Boolean vencidos = false;
            List<Modelo.Sorteo> sorteos = log.listaSorteos();

            for (int i = 0; i <sorteos.Count; i++)
            {
                if (sorteos[i].fecha.CompareTo(DateTime.Now) == -1)
                {
                    if (sorteos[i].estado)
                    {
                        cont++;
                        int id = Convert.ToInt32(sorteos[i].id);
                        string descripcion = sorteos[i].descripcion;
                        DateTime fecha = Convert.ToDateTime(sorteos[i].fecha);
                        Boolean estado = false;
                        string codigo = sorteos[i].codigo;
                        sorteo.Update(id, descripcion, fecha, estado, codigo);
                        vencidos = true;
                    }
                 
                }
            }
            if (vencidos)
            {
                if (privilegios == true)
                {
                    MessageBox.Show("Hay sorteos ya caducados Favor revisar y premiar los sorteos" + "\nSorteos Caducados: " + cont);
                }
            }
            
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nombre: "+person.nombre+"\nApellido: " + person.apellido + "\nCorreo: " + person.correo);
        }

        private void timerValidacion_Tick(object sender, EventArgs e)
        {
            sorteosVencidos();
            
        }

        private void tablaGanadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.HandleForm(this.oGanadores))
            {
                this.oGanadores = new FrmGanadores(privilegios, person);
                oGanadores.MdiParent = this;
                oGanadores.Show();
            }
        }

        private void gananciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.HandleForm(this.oGanancias))
            {
                this.oGanancias = new FrmGanancias();
                oGanancias.MdiParent = this;
                oGanancias.Show();
            }

        }
    }
    }

