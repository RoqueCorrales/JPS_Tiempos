using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess;
using System.Data;

namespace ProyectoTiempos.Controlador
{
    public class Persona : ErrorHandler
    {
        private Modelo.Persona persona;

        public Persona()
        {
            this.persona = new Modelo.Persona();
        }


        public void Insert(string nombre, string apellido, string cedula, string contrasenna, string correo)
        {
            this.persona = new Modelo.Persona(nombre, apellido, cedula, contrasenna, correo);
            this.persona.Insert();
            if (this.persona.isError)
            {
                this.isError = true;
                this.errorDescription = this.persona.errorDescription;
            }
        }

        public DataTable Select(string correo)
        {
            DataTable result = new DataTable();
            result = this.persona.Select(correo);
            if (this.persona.isError)
            {
                this.isError = true;
                this.errorDescription = this.persona.errorDescription;
            }
            return result;
        }

        public DataTable SelectPorId(int id)
        {
            DataTable result = new DataTable();
            result = this.persona.SelectPorId(id);
            if (this.persona.isError)
            {
                this.isError = true;
                this.errorDescription = this.persona.errorDescription;
            }
            return result;
        }


    }
}
