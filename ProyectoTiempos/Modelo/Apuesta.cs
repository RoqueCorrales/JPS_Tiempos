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

        /*Metodo de insertar una apuesta a nuestra base de Datos. 
         * Recibe id_persona, id_sorteo,monto ,numero.
         * Usando los parametros del constructor.
         */
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

        /*
         *Hace un select completo a nuestra tabla sorteos.
         * retorna un datatable. 
         */
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

        /*Selecciona una apuesta por id.
      *  id parametro que recibe.
      *  Devuelve un DATATABLE.
      */
        public DataTable SelectApuesta(int id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("id_sorteo", id);
            DataTable result = Program.da.SqlQuery("select * from apuesta where id_sorteo = '" + id + "'", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }

        /*
         *Seleciona el dinero apostado a un numero. 
         * Recibe de parametros id_sorteo, numero.
         * Devuelve un DATATABLE.
         * 
         */
        public DataTable SelectDineroApostadoAunnumero(int id_sorteo, int numero)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("id_sorteo", id_sorteo);
            parametros.Add("numero", numero);
            DataTable result = Program.da.SqlQuery("SELECT sum(monto_apostado) FROM public.apuesta where id_sorteo = " + id_sorteo + " and numero = " + numero, new Dictionary<string, object>());
            //DataTable result = Program.da.SqlQuery("SELECT sum(monto_apostado) FROM public.apuesta where id_sorteo = @id_sorteo and numero = @numero", parametros);
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }
        /*
        *Selecciona los numeros apostados a un sorteo. 
        * Recibe de parametro un id, que sera el id del sorteo.
        * Devuelve un DATATABLE.
        */
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
        /*
         * Busca y Devuelve el monto maximo que hay en apuesta
         * devuelve un DATATABLE
         */
        public DataTable SelectMontoMaximo()
        {
            DataTable result = Program.da.SqlQuery("Select a.id , a.id_persona ,a.id_sorteo , a.numero ,a.monto_apostado From apuesta a Where a.monto_apostado = (Select MAX (monto_apostado) From apuesta)", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }
        /*
         * Busca y apuesta por numero
         * devuelve un DATATABLE
         */
        public DataTable SelectApuestaNumero(int numero)
        {
            DataTable result = Program.da.SqlQuery("select * from apuesta where numero= '" + numero + "'", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }
        /*
        * Suma de los montos de un numero
        * devuelve un DATATABLE
        */
        public DataTable SelectSumaMontoNumero(int numero , int sorteo)
        {
            DataTable result = Program.da.SqlQuery("SELECT sum(monto_apostado) FROM public.apuesta where numero = "+numero +" and id_sorteo = "+sorteo+";", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }

        /*
       * Ordena los numero de forma descendente (monto apostado)
       * devuelve un DATATABLE
       */
        public DataTable SelectMontoDescendente(int id_sorteo)
        {
            DataTable result = Program.da.SqlQuery("select distinct (numero),sum(monto_apostado) from apuesta where id_sorteo ="+id_sorteo +" group by numero order by sum desc;", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }

        /*
      *Hace un select completo PARA NUESTRA TABLA GANADORES.
      * retorna un datatable. 
      */
        public DataTable SelectParaTablaGanadores(int id_sorteo)
        {
            DataTable result = Program.da.SqlQuery("SELECT  apuesta.numero, persona.nombre,apuesta.monto_apostado, sorteo.fecha,numpremiados.codigo_sorteo" +
           "FROM public.apuesta, public.persona, public.numpremiados,  public.sorteo WHERE apuesta.id_persona = persona.id AND " +
           " numpremiados.numerouno = apuesta.numero OR numpremiados.numerodos = apuesta.numero OR numpremiados.numerotres = apuesta.numero AND "+
           " sorteo.id = " + id_sorteo + " AND sorteo.id =" + id_sorteo+";", new Dictionary<string, object>());
            if (Program.da.isError)
            {
                this.isError = true;
                this.errorDescription = Program.da.errorDescription;
            }
            return result;
        }




    }
}