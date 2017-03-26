using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiempos.Utils
{
    public class LogicaCasaNoPierde
    {
        private Logica log;
        private Modelo.Sorteo sor;
        private Controladores.Sorteo sorteo;
        private Controladores.Apuesta apu;
        private Modelo.SorteoPremiado sorPre;
        private List<Modelo.DineroAPagar> listaDineroTotalPorNumero;
        private List<int> listaNumeros;
        private double montoCasa;
        private double primerPremio;
        private double segundoPremio;
        private double tercerPremio;

        private Modelo.DineroAPagar dpagar;
        public LogicaCasaNoPierde()
        {
            log = new Logica();
            sor = new Modelo.Sorteo();
            apu = new Controladores.Apuesta();
            sorPre = new Modelo.SorteoPremiado();
            sorteo = new Controladores.Sorteo();
            dpagar = new Modelo.DineroAPagar();
            listaDineroTotalPorNumero = new List<Modelo.DineroAPagar>();
            listaNumeros = new List<int>();
        }

        private List<Modelo.Sorteo> TraerSorteosNOpagados()
        {

            List<Modelo.Sorteo> lista = new List<Modelo.Sorteo>();
            DataTable result = new DataTable();
            result = this.sorteo.SelectCodigo();

            for (int i = 0; i < result.Rows.Count; i++)
            {
                Modelo.Sorteo s = new Modelo.Sorteo();
                s.fecha = Convert.ToDateTime(result.Rows[i]["fecha"]);
                s.estado = Convert.ToBoolean(result.Rows[i]["estado"]);
                s.descripcion = result.Rows[i]["descripcion"].ToString();
                s.id = Convert.ToInt32(result.Rows[i]["id"]);
                s.codigo = (result.Rows[i]["codigo"].ToString());

                lista.Add(s);
            }

            return lista;


        }


        public void recorrerLista()
        {
            List<Modelo.Sorteo> lista = new List<Modelo.Sorteo>();
            lista =TraerSorteosNOpagados();

            for (int i = 0; i < lista.Count; i++)
            {
                int id = lista[i].id;
                DineroAPagar(id);
            }
        }


        private  List<Modelo.Apuesta> DineroAPagar(int id_sorteo)
        {
            
            DataTable result = new DataTable();
            List<Modelo.Apuesta> listaApuestas = new List<Modelo.Apuesta>();
            List<Modelo.Apuesta> listaApuestasModificada = new List<Modelo.Apuesta>();
            DataTable resultNumeros = new DataTable();
            resultNumeros = apu.SelectApuestaNumerosDistintos(id_sorteo);
            if (resultNumeros.Rows.Count > 0)
            {

                for (int i = 0; i < resultNumeros.Rows.Count; i++)
                {
                    listaNumeros.Add(Convert.ToInt32(resultNumeros.Rows[i]["numero"]));
                }

                for (int i = 0; i < listaNumeros.Count; i++)
                {
                    DineroApostadoAunNumero(id_sorteo, listaNumeros[i]);
                }

            }

            return listaApuestasModificada;
        }

        public void DineroApostadoAunNumero(int id_sorteo,int numero)
        {
            DataTable result = new DataTable();
            result = apu.SelectDineroApostadoAunnumero(id_sorteo, numero);
           
            for (int i = 0; i < result.Rows.Count; i++)
            {
                Modelo.DineroAPagar dp = new Modelo.DineroAPagar();
                dp.monto = Convert.ToInt32(result.Rows[i]["sum"]);
                dp.id_sorteo = id_sorteo;
                dp.numero = numero;
                listaDineroTotalPorNumero.Add(dp);
            }



        }



        public List<Modelo.DineroAPagar> ListaDineroPagar(List<Modelo.Apuesta> listaApuestas)
        {
              List<Modelo.DineroAPagar> listaDineroApagar = new List<Modelo.DineroAPagar>();

            
            

            return listaDineroApagar;
        }

        public void suma(int id_sorteo)
        {

        }



    }
}
