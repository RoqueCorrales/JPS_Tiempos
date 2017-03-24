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