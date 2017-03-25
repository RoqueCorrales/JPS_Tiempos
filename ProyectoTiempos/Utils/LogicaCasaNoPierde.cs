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

            result = apu.SelectApuesta(id_sorteo);
            for (int i = 0; i < result.Rows.Count; i++)
            {
                 Modelo.Apuesta apuesta = new Modelo.Apuesta();
                apuesta.id = Convert.ToInt32(result.Rows[i]["id"]);
                apuesta.id_persona = Convert.ToInt32(result.Rows[i]["id_persona"]);
                apuesta.id_sorteo = Convert.ToInt32(result.Rows[i]["id_sorteo"]);
                apuesta.numero = Convert.ToInt32(result.Rows[i]["numero"]);
                apuesta.monto = Convert.ToDouble(result.Rows[i]["monto_apostado"]);
                listaApuestas.Add(apuesta);
                if(listaApuestasModificada.Count == 0)
                {
                    listaApuestasModificada.Add(apuesta);
                }else
                {
                    for (int j = 0; j < listaApuestasModificada.Count; j++)
                    {
                        if (listaApuestasModificada[j].numero == apuesta.numero)
                        {
                            apuesta.monto = apuesta.monto + listaApuestas[j].monto;
                            listaApuestasModificada.Add(apuesta);
                        }
                        else
                        {
                            listaApuestasModificada.Add(apuesta);
                        }

                    }
                }
               
                
            }

            return listaApuestasModificada ;
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
