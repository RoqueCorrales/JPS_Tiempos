﻿using DBAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiempos.Controladores
{
    class SorteoPremiado : ErrorHandler
    {
        private Modelo.SorteoPremiado sorPre;
      
        public SorteoPremiado()
        {
            this.sorPre = new Modelo.SorteoPremiado();
        }

        /*
         *Inserta SorteosPremiados.
         * Recibe codigo_sorteo, numUno,numDos,numTres y un id-sorteo. 
         */
        public void Insert( string codigo_sorteo, int numUno, int numDos, int numTres, int id_sorteo)
        {
            this.sorPre = new Modelo.SorteoPremiado();
            this.sorPre.Insert(codigo_sorteo,numUno,numDos,numTres,id_sorteo);
            if (this.sorPre.isError)
            {
                this.isError = true;
                this.errorDescription = this.sorPre.errorDescription;
            }
        }
        /*
         * Hace un select completo a nuestros sorteos premiados.
         */
        public DataTable Select()
        {
            DataTable result = new DataTable();
            result = new DataTable();
            result = this.sorPre.Select();
            if (this.sorPre.isError)
            {
                this.isError = true;
                this.errorDescription = this.sorPre.errorDescription;
            }
            return result;
        }

        /*
         * Hace un select por codigo a nuestros sorteos premiados.
         */
        public DataTable SelectPorCodigo(string cod)
        {
            DataTable result = new DataTable();
            result = new DataTable();
            result = this.sorPre.SelectPorCodigo(cod);
            if (this.sorPre.isError)
            {
                this.isError = true;
                this.errorDescription = this.sorPre.errorDescription;
            }
            return result;
        }
    }
}
