using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess;
using System.Data;

namespace ProyectoTiempos.Controladores
{
    class Apuesta : ErrorHandler
    {
        private Modelo.Apuesta apuesta;

        public Apuesta()
     {
         this.apuesta = new Modelo.Apuesta();
        }

        /*Metodo de insertar una apuesta a nuestra base de Datos. 
         * Recibe id_persona, id_sorteo,monto ,numero.
         */
        public void Insert(int id_persona, int id_sorteo, double monto, int numero)
        {
            this.apuesta = new Modelo.Apuesta(id_persona, id_sorteo, monto, numero);
            this.apuesta.Insert();
            if (this.apuesta.isError)
            {
            this.isError = true;
            this.errorDescription = this.apuesta.errorDescription;
               }
        }

        /*Selecciona una apuesta por id.
         *  id parametro que recibe.
         *  Devuelve un DATATABLE.
         */
        public DataTable SelectApuesta(int id)
        {
            DataTable result = new DataTable();
            result = new DataTable();
            result = this.apuesta.SelectApuesta(id);
            if (this.apuesta.isError)
            {
                this.isError = true;
                this.errorDescription = this.apuesta.errorDescription;
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
            DataTable result = new DataTable();
            result = new DataTable();
            result = this.apuesta.SelectDineroApostadoAunnumero(id_sorteo, numero);
            if (this.apuesta.isError)
            {
                this.isError = true;
                this.errorDescription = this.apuesta.errorDescription;
            }
            return result;
        }

        /*
         *Selecciona los numeros apostados a un sorteo. 
         * Recibe de parametro un id, que sera el id del sorteo.
         * Devuelve un DATATABLE.
         */
        public DataTable SelectApuestaNumerosDistintos(int id)
        {
            DataTable result = new DataTable();
            result = new DataTable();
            result = this.apuesta.SelectApuestaNumerosDistintos(id);
            if (this.apuesta.isError)
            {
                this.isError = true;
                this.errorDescription = this.apuesta.errorDescription;
            }
            return result;
        }


        /*Selecciona una apuesta por id.
        *  id parametro que recibe.
        *  Devuelve un DATATABLE para la tablaganadores.
        */
        public DataTable SelectParaTablaGanadores(int id_sorteo)
        {
            DataTable result = new DataTable();
            result = new DataTable();
            result = this.apuesta.SelectApuesta(id_sorteo);
            if (this.apuesta.isError)
            {
                this.isError = true;
                this.errorDescription = this.apuesta.errorDescription;
            }
            return result;
        }

        public DataTable SelectGanaciaMaxima(int id_sorteo)
        {
            DataTable result = new DataTable();
            result = new DataTable();
            result = this.apuesta.SelectGananciaMaxima(id_sorteo);
            if (this.apuesta.isError)
            {
                this.isError = true;
                this.errorDescription = this.apuesta.errorDescription;
            }
            return result;
        }

        public DataTable SelectMontoDescendente(int id_sorteo)
        {
            DataTable result = new DataTable();
            result = new DataTable();
            result = this.apuesta.SelectMontoDescendente(id_sorteo);
            if (this.apuesta.isError)
            {
                this.isError = true;
                this.errorDescription = this.apuesta.errorDescription;
            }
            return result;
        }
    }
}