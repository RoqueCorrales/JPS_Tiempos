using DBAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiempos.Modelo
{
    public class SorteoPremiado : ErrorHandler
    {
        public int id { set; get; }
        public string codigo_sorteo { set; get; }
        public int numUno { set; get; }
        public int numDos { set; get; }
        public int numTres { set; get; }
        public int id_sorteo { set; get; }
        public Boolean pagado { set; get; }




        /*
         *Inserta SorteosPremiados.
         * Recibe codigo_sorteo, numUno,numDos,numTres y un id-sorteo. 
         */
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


        /*
         * Hace un select completo a nuestros sorteos premiados.
         */
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

        /*
        * Hace un select por codigo a nuestros sorteos premiados.
        */
        public DataTable SelectPorCodigo(string cod)
        {
            DataTable result = Program.da.SqlQuery("select * from  public.numpremiados where codigo_sorteo = '" + cod +"';", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }
    }
}
