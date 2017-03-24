using System;
using System.Windows.Forms;
using ProyectoTiempos.Controlador;
using System.Data;

namespace ProyectoTiempos
{
    public partial class FrmLogin : Form
    {
        Persona persona;

        private FrmPrincipal oPrincipal;
        public FrmLogin()
        {
            InitializeComponent();
            this.persona = new Persona();
            CifrarContrasenha();

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            correoRegistrado();
        }
        private void CifrarContrasenha()
        {
            txtContrasenna.Text = "";
            txtContrasenna.PasswordChar = '*';
            txtContrasenna.MaxLength = 15;
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FrmRegistro oRegistro = new FrmRegistro();
            oRegistro.ShowDialog();
        }





        private Boolean correoRegistrado()
        {
            DataTable p = persona.Select(txtCorreo.Text);
            if (p.Rows.Count <= 0)
            {
                MessageBox.Show("Correo no registrado");
                return false;
            }
            DataRow row = p.Rows[0];
            string id = row["id"].ToString();
            string pass = row["contrasenna"].ToString();
            string nombre = row["nombre"].ToString();
            string cedula = row["cedula"].ToString();
            String correo = row["correo"].ToString();
            string apellido = row["apellido"].ToString();
            String priv = row["privilegios"].ToString();
            Boolean privilegios = Convert.ToBoolean(priv);

            if (txtCorreo.Text.Equals(correo) && txtContrasenna.Text.Equals(pass))
            {
                Modelo.Persona person = new Modelo.Persona();
                person.nombre = nombre;
                person.id = Convert.ToInt32(id);
                person.cedula = cedula;
                person.apellido = apellido;
                person.contrasenna = pass;
                person.correo = correo;

                oPrincipal = new FrmPrincipal(privilegios, person);
                oPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales no validos");
            }
            return true;

        }





    }
}

