using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess;
using System.Data;

namespace ProyectoTiempos.Modelo
{
    public class Sorteo : ErrorHandler
    {
        public int id { set; get; }
        public DateTime fecha { set; get; }
        public string descripcion { set; get; }
        public Boolean estado { set; get; }
        public string codigo { set; get; }

        public Sorteo()
        {
                
        }
     

        public Sorteo(string descripcion, string codigo, DateTime fecha, bool estado)
        {
            this.descripcion = descripcion;
            this.codigo = codigo;
            this.fecha = fecha;
            this.estado = estado;
        }

        public DataTable SelectCodigo()
        {
            DataTable result = Program.da.SqlQuery("select * from sorteo ;", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }
        public DataTable SelectSorteosEstadoTrue()
{
            DataTable result = Program.da.SqlQuery("SELECT * FROM public.sorteo WHERE estado = True;", new Dictionary<string, object>());
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
            parametros.Add("fecha", this.fecha);
            parametros.Add("estado", this.estado);
            parametros.Add("descripcion", this.descripcion);
            parametros.Add("codigo", this.codigo);
            
            DataTable result = Program.da.SqlQuery("insert into sorteo(descripcion,fecha,estado,codigo ) values (@descripcion ,@fecha,@estado,@codigo) returning id;", parametros);
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
       

        public void Update(int id, string descripcion, DateTime fecha,Boolean estado, string codigo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("descripcion", descripcion);
            parametros.Add("fecha", fecha);
            parametros.Add("estado", estado);
            parametros.Add("codigo", codigo);
            parametros.Add("id", id);
            Program.da.SqlStatement("update sorteo set descripcion=@descripcion, fecha=@fecha, estado=@estado, codigo=@codigo where id = @id", parametros);
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
                return;
            }
        }
        public DataTable SelectCodigo(String codigo)
        {

            DataTable result = Program.da.SqlQuery("select * from sorteo where codigo = '" + codigo + "'", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }

        public DataTable SelectSorteosEstadoFalse()
        {
            DataTable result = Program.da.SqlQuery("SELECT * FROM public.sorteo WHERE estado = false;", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;

            }
            return result;
        }
    }
}
