using DBAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiempos.Modelo
{
    class SorteoPremiado : ErrorHandler
    {
        private int id { set; get; }
        private string codigo_sorteo { set; get; }
        private int numUno { set; get; }
        private int numDos { set; get; }
        private int numTres { set; get; }
        private int id_sorteo { set; get; }
        private Boolean pagado { set; get; }





        public void Insert( string codigo_sorteo,int numUno,int numDos,int numTres, int id_sorteo)
        {
            Boolean pagado = false;
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("numeroUno", numUno);
            parametros.Add("numeroDos", numDos);
            parametros.Add("numeroTres", numTres);
            parametros.Add("id_sorteo", id_sorteo);
            parametros.Add("codigo_sorteo", codigo_sorteo);
            parametros.Add("pagado", pagado);

            DataTable result = Program.da.SqlQuery("insert into numPremiados (numerouno, numerodos, numerotres, id_sorteo, codigo_sorteo, pagado ) values (@numerouno, @numerodos, @numerotres, @id_sorteo, @codigo_sorteo, @pagado) returning id;", parametros);
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


        public DataTable Select()
        {
            DataTable result = Program.da.SqlQuery("select * from  public.numpremiados;", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }
    }
}
