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


    }
}