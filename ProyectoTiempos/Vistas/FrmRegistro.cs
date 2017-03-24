using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoTiempos.Controlador;

namespace ProyectoTiempos
{

    public partial class FrmRegistro : Form
    {

        private Persona persona;
        public FrmRegistro()
        {
            InitializeComponent();
            persona = new Persona();
            CifrarContrasenha();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CifrarContrasenha()
        {
            txtContrasenna.Text = "";
            txtContrasennaConfirm.Text = "";
            txtContrasennaConfirm.PasswordChar = '*';
            txtContrasenna.PasswordChar = '*';
            txtContrasenna.MaxLength = 15;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DataTable p = persona.Select(txtCorreo.Text);
            if (camposLlenos())
            {

                if (p.Rows.Count <= 0)
                {
                    String nombre = txtNombre.Text;
                    String apellido = txtApellido.Text;
                    String cedula = txtCedula.Text;
                    String contrasennna = txtContrasenna.Text;
                    String correo = txtCorreo.Text;

                   

                    persona.Insert(nombre, apellido, cedula, contrasennna, correo);

                    MessageBox.Show("Usuario Registrado");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("El correo pertenece a una cuenta ya registrada");

                }
            }

        }
        public Boolean PasswordConfirm()
        {
            if (txtContrasenna.Text.Equals(txtContrasennaConfirm.Text))
            {
                return true;
            }
            MessageBox.Show("--------------------Oops!-----------------\n" +
                            "        Contraseñas no son iguales");
            return false;
        }
        private Boolean camposLlenos()
        {

            if (txtNombre.Text.Equals("") || txtNombre.Equals(" "))
            {
                MessageBox.Show("Nombre Invalido");
                return false;

            }
            else if (txtApellido.Text.Equals("") || txtApellido.Equals(" "))
            {
                MessageBox.Show("Apellido Invalido");
                return false;
            }
            else if (txtCedula.Text.Equals("") || txtCedula.Equals(" "))
            {
                MessageBox.Show("Cedula Invalida");
                return false;
            }
            else if (txtContrasenna.Text.Equals("") || txtContrasenna.Equals(" "))
            {
                MessageBox.Show("Contraseña Invalida");
                return false;
            }
            else if (txtCorreo.Text.Equals("") || txtCorreo.Equals(" "))
            {
                MessageBox.Show("Correo Invalido");
                return false;
            }
            else
            {
                return true;
            }


        }
     

    }


}
