using System;
using System.Collections.Generic;
using DBAccess;
using System.Data;

namespace ProyectoTiempos.Modelo
{
    public class Apuesta : ErrorHandler
    {

        public int id { set; get; }
        public int id_persona { set; get; }
        public int id_sorteo { set; get; }
        public double monto { set; get; }
        public int numero { set; get; }


        public Apuesta()
        {

        }
        public Apuesta(int id_persona, int id_sorteo, double monto, int numero)
        {
            this.id_persona = id_persona;
            this.id_sorteo = id_sorteo;
            this.monto = monto;
            this.numero = numero;
        }

        public void Insert()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("id_persona", this.id_persona);
            parametros.Add("id_sorteo", this.id_sorteo);
            parametros.Add("numero", this.numero);
            parametros.Add("monto", this.monto);
            DataTable result = Program.da.SqlQuery("insert into apuesta (id_persona,id_sorteo,numero,monto_apostado) values (@id_persona,@id_sorteo,@numero,@monto) returning id;", parametros);
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
            DataTable result = Program.da.SqlQuery("select * from apuesta;", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }
        public DataTable SelectApuesta(int id)
        {
            DataTable result = Program.da.SqlQuery("select * from apuesta where id_sorteo = '" + id + "'", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }

        public DataTable SelectDineroApostadoAunnumero(int id_sorteo, int numero)
        {
            DataTable result = Program.da.SqlQuery("SELECT sum(monto_apostado) FROM public.apuesta where id_sorteo = "+id_sorteo+" and numero = "+numero, new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }

        public DataTable SelectApuestaNumerosDistintos(int id_sorteo)
        {
            DataTable result = Program.da.SqlQuery("select  DISTINCT numero from apuesta where id_sorteo = '" + id_sorteo + "'", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }
    }
}