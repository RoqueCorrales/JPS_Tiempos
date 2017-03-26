using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess;
using System.Data;

namespace ProyectoTiempos.Controladores
{

    class Casa : ErrorHandler
    {
        private Modelo.Casa casa;

        public Casa()
        {
            this.casa = new Modelo.Casa();
        }

        /* Insertar Configuracion de la casa.
         * Recibe dos parametros, un nombre, y un monto inicial.
         */
        public void Insert(string nombre, double dinero)
        {
            this.casa = new Modelo.Casa(nombre, dinero);
            this.casa.Insert();
            if (this.casa.isError)
            {
                this.isError = true;
                this.errorDescription = this.casa.errorDescription;
            }
        }

        /*
         * Hace un select completo a los datos de la casa.
         * Devuelve un DATATABLE.
         */
        public DataTable Select()
        {
            DataTable result = new DataTable();
            result = this.casa.Select();
            if (this.casa.isError)
            {
                this.isError = true;
                this.errorDescription = this.casa.errorDescription;
            }
            return result;
        }

        /* 
         *Hace un UPDATE a la casa.
         * recibe un id, un nombre, y un dinero. 
         */
        public void Update(int id, string nombre, double dinero)
        {
            this.casa = new Modelo.Casa(nombre, dinero);
            this.casa.Update(id);
            if (this.casa.isError)
            {
                this.isError = true;
                this.errorDescription = this.casa.errorDescription;
            }
        }

        /* 
       *Hace un UPDATE al Dinero de la casa.
       * recibe un id,  y un dinero. 
       */
        public void UpdateDinero(int id, double dinero)
        {
            this.casa = new Modelo.Casa(dinero);
            this.casa.Update(id);
            if (this.casa.isError)
            {
                this.isError = true;
                this.errorDescription = this.casa.errorDescription;
            }
        }



    }
}