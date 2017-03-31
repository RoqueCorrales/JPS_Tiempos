using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess;

namespace ProyectoTiempos.Modelo
{
    public class Casa : ErrorHandler
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double dinero { get; set; }

        public Casa()
        {

        }

        public Casa(string nombre, double dinero)
        {
            this.nombre = nombre;
            this.dinero = dinero;
        }

        public Casa(double dinero)
        {

            this.dinero = dinero;
        }



        /*
        * Hace un select completo a los datos de la casa.
        * Devuelve un DATATABLE.
        */
        public DataTable Select()
        {
            DataTable result = Program.da.SqlQuery("select * from configuracion;", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }

     /*
    * Hace un select del dinero de la casa.
    * Devuelve un DATATABLE.
    */
        public DataTable SelectDineroCasa()
        {
            DataTable result = Program.da.SqlQuery("select dinero from configuracion;", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }

        /* Insertar Configuracion de la casa.
         * Recibe dos parametros, un nombre, y un monto inicial.
         */
        public void Insert()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("nombre", this.nombre);
            parametros.Add("dinero", this.dinero);
            DataTable result = Program.da.SqlQuery("insert into configuracion (nombre,dinero) values (@nombre ,@dinero) returning id;", parametros);
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

        /* 
         *Hace un UPDATE a la casa.
         * recibe un id, un nombre, y un dinero. 
         */
        public void Update(int id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("nombre", this.nombre);
            parametros.Add("dinero", this.dinero);
            parametros.Add("id", id);
            Program.da.SqlStatement("update configuracion set nombre= @nombre, dinero=@dinero where id = @id", parametros);
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
                return;
            }
        }
        /* 
       *Hace un UPDATE al Dinero de la casa.
       * recibe un id,  y un dinero. 
       */
        public void UpdateDinero(int id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("dinero", this.dinero);
            parametros.Add("id", id);
            Program.da.SqlStatement("update configuracion set dinero=@dinero where id = @id", parametros);
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
                return;
            }
        }


    }
}
