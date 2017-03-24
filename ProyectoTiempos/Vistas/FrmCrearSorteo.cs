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
    public partial class FrmCrearSorteo : Form
    {
        
        private Serial serial;
        private Sorteo sorteo;
        private Logica log;
        private int id;
        public FrmCrearSorteo()
        {

            InitializeComponent();
            serial = new Serial();
            sorteo = new Sorteo();
            log = new Logica();
             Refrescar();
           
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            serial = new Serial();
            lblSerial.Text = serial.sacarSerial();
            btnGenerar.Visible = false;
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                DateTime fecha = dtHora.Value.Date +
                                    dtHora.Value.TimeOfDay;


                string descripcion = txtDescripcion.Text;
                string codigo = lblSerial.Text;
                Boolean estado = false;
                if (rbHabilitar.Checked)
                {
                    estado = true;
                }



                if (log.existeSorteo(lblSerial.Text))
                {
                    this.sorteo.Update(id, descripcion, fecha, estado, codigo);
                }
                else
                {

                    sorteo.Insert(descripcion, codigo, fecha, estado);

                }


                Refrescar();

            }


        }
        private void Refrescar()
        {
            DataTable result = new DataTable();
            result = this.sorteo.SelectCodigo();
            txtDescripcion.Text = "";
            lblSerial.Text = "";
            dtHora.Value = DateTime.Now;
            this.id = new Int32();
            btnGenerar.Visible = true;
            if (this.sorteo.isError)
            {
                MessageBox.Show(this.sorteo.errorDescription);
                return;
            }
            this.dtgSorteo.DataSource = result;
        }

      

        private void dtgSorteo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             id = Convert.ToInt32(this.dtgSorteo.CurrentRow.Cells[0].Value.ToString());
            string descripcion = this.dtgSorteo.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = descripcion;
            DateTime fecha = DateTime.Parse(this.dtgSorteo.CurrentRow.Cells[2].Value.ToString());
            dtHora.Value = fecha;
            Boolean estado = Convert.ToBoolean(this.dtgSorteo.CurrentRow.Cells[3].Value.ToString()); ;
            if (estado)
            {
                rbHabilitar.Select();
            }else
            {
                rbDeshabilitar.Select();
            }
            string codigo = this.dtgSorteo.CurrentRow.Cells[4].Value.ToString();
            lblSerial.Text = codigo;
            

            if (this.sorteo.isError)
            {
                MessageBox.Show(this.sorteo.errorDescription);
                return;
            }

        }
        private Boolean ValidarCampos()
        {
            if (dtHora.Value.CompareTo(DateTime.Now) == -1)
            {
                MessageBox.Show("Fecha Invalida");
                return false;

            }else
            {
                if (string.IsNullOrEmpty(lblSerial.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    MessageBox.Show("Todos los campos no estan llenos");
                    return false;
                }
            }
            


            return true;
        }
    }
}
