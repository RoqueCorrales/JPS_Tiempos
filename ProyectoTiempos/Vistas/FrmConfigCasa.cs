using ProyectoTiempos.Controladores;
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
    public partial class FrmConfigCasa : Form
    {
        private Casa casa;
        public FrmConfigCasa()
        {
            InitializeComponent();
            casa = new Casa();
            casaInicio();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String nombre = txtNombre.Text;

                if (validacionDinero())
                {
                    double dinero = Convert.ToDouble(txtDinero.Text);
                    casa.Insert(nombre, dinero);
                    MessageBox.Show("Configuracion establecida");


                }

            }
            catch (Exception)
            {
                MessageBox.Show("Problema.");
            }

        }

        private Boolean validacionDinero()
        {
            Boolean a = false;

            try
            {
                Convert.ToDouble(txtDinero.Text);
                a = true;
            }
            catch (Exception e)
            {
                a = false;
                MessageBox.Show("Digite una cantidad de dinero valida, sin caracteres especiales");

            }
            if (a)
            {
                return true;
            }
            return false;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                double dinerin = Convert.ToDouble(txtDinero.Text);
                if (dinerin > 0)
                {
                    String nombre = txtNombre.Text;

                    DataTable tableCasa = casa.Select();
                    if (tableCasa.Rows.Count > 0)
                    {
                        if (validacionDinero())
                        {

                            DataRow row = tableCasa.Rows[0];
                            int id = Convert.ToInt32(row["id"].ToString());
                            casa.Update(id, txtNombre.Text, Convert.ToInt64(txtDinero.Text));
                            MessageBox.Show("Configuracion Actualizada");
                        }

                    }
                    else
                    {
                        if (validacionDinero())
                        {
                            double dinero = Convert.ToDouble(txtDinero.Text);
                            casa.Insert(nombre, dinero);
                            MessageBox.Show("Configuracion establecida");

                        }

                    }
                }
                else
                {
                    MessageBox.Show("Dinero invalido");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Problema");
            }
        }

        private void casaInicio()
        {
            DataTable tableCasa = casa.Select();
            DataRow row = tableCasa.Rows[0];
            int id = Convert.ToInt32(row["id"].ToString());
            txtNombre.Text = (row["nombre"].ToString());
            txtDinero.Text = (row["dinero"].ToString());
        }
    }
}
