using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess;

namespace ProyectoTiempos.Modelo
{
    public class Persona : ErrorHandler
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string contrasenna { get; set; }
        public string correo { get; set; }
        public Boolean privilegios { get; set; }

        public Persona()
        {

        }

        public Persona(String nombre, string apellido, string cedula, string contrasenna, string correo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.contrasenna = contrasenna;
            this.correo = correo;
        }

        public DataTable Select()
        {
            DataTable result = Program.da.SqlQuery("select * from persona;", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }

        public void Insert()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("nombre", this.nombre);
            parametros.Add("apellido", this.apellido);
            parametros.Add("cedula", this.cedula);
            parametros.Add("contrasenna", this.contrasenna);
            parametros.Add("correo", this.correo);
            DataTable result = Program.da.SqlQuery("insert into persona (nombre,apellido,cedula,contrasenna,"
                + "correo,privilegios) values (@nombre ,@apellido,@cedula,@contrasenna,@correo,false) returning id;", parametros);
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
                return;
            }
            if (result.Rows.Count > 0)
            {
                this.id = Convert.ToInt32(result.Rows[0]["id"]);
            }




        }
        public DataTable Select(string correo)
        {

            DataTable result = Program.da.SqlQuery("select * from persona where correo = '" + correo + "'", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }

        public DataTable SelectPorId(int id)
        {

            DataTable result = Program.da.SqlQuery("select * from persona where id = '" + id + "'", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }










    }
}
