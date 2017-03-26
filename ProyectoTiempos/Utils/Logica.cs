using DBAccess;
using ProyectoTiempos.Controladores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTiempos.Utils
{
    public class Logica : ErrorHandler
    {
        private Sorteo sorteo;
        private Notificacion not;
        private SorteoPremiado sorPre;
        private List<Modelo.Sorteo> lista;
        private Modelo.Apuesta apuesta;
        private Modelo.Persona persona;
        public Logica()
        {
            sorteo = new Sorteo();
            sorPre = new SorteoPremiado();
            lista = new List<Modelo.Sorteo>();
            apuesta = new Modelo.Apuesta();
            persona = new Modelo.Persona();
            not = new Notificacion();
        }


        public List<string> cargarCombo()
        {
            DataTable result = new DataTable();

            result = this.sorteo.SelectSorteosEstadoFalse();
            List<string> lista = new List<string>();
            if (this.sorteo.isError)
            {
                this.isError = true;
                this.errorDescription = this.sorteo.errorDescription;
            }
            for (int i = 0; i < result.Rows.Count; i++)
            {
                lista.Add(result.Rows[i]["codigo"].ToString());
            }


            return lista;
        }


        public int buscarID(string codigo)
        {
            int id_sorteo;
            DataTable result = new DataTable();
            result = this.sorteo.SelectCodigo(codigo);
            DataRow row = result.Rows[0];
            string id = row["id"].ToString();
            id_sorteo = Convert.ToInt32(id);
            return id_sorteo;
        }


        public Boolean existeSorteo(string codigo)
        {
            DataTable sor = new DataTable();

            sor = sorteo.SelectCodigo(codigo);

            if (sor.Rows.Count > 0)
            {
                return true;
            }


            return false;
        }


        public List<String> cargarComboxSorteosNoPremiados()
        {

            DataTable todos = new DataTable();
            DataTable resultPremiados = new DataTable();

            todos = sorteo.SelectSorteosEstadoTrue();
            resultPremiados = sorPre.Select();
            List<string> lista = new List<string>();


            for (int i = 0; i < todos.Rows.Count; i++)
            {
                string a = (todos.Rows[i]["codigo"]).ToString();
                lista.Add(a);
            }

            for (int j = 0; j < resultPremiados.Rows.Count; j++)
            {
                string a = resultPremiados.Rows[j]["codigo_sorteo"].ToString();
                if (lista.Contains(a))
                {
                    lista.Remove(a);
                }
            }
            return lista;


        }
        public List<string> cargarComboEstadoTrue()
        {
            DataTable result = new DataTable();
            result = this.sorteo.SelectSorteosEstadoTrue();
            List<string> lista = new List<string>();
            if (this.sorteo.isError)
            {
                this.isError = true;
                this.errorDescription = this.sorteo.errorDescription;
            }
            for (int i = 0; i < result.Rows.Count; i++)
            {

                lista.Add(result.Rows[i]["codigo"].ToString());


            }
            return lista;
        }


        public List<Modelo.Sorteo> listaSorteos()
        {

            lista = new List<Modelo.Sorteo>();
            DataTable result = new DataTable();
            result = this.sorteo.SelectSorteosEstadoTrue();

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

        public Modelo.Sorteo buscarInfoSorteo(string codigo)
        {
            Modelo.Sorteo s = new Modelo.Sorteo();
            DataTable result = new DataTable();
            result = sorteo.SelectCodigo(codigo);
            for (int i = 0; i < result.Rows.Count; i++)
            {

                s.fecha = Convert.ToDateTime(result.Rows[i]["fecha"]);
                s.estado = Convert.ToBoolean(result.Rows[i]["estado"]);
                s.descripcion = result.Rows[i]["descripcion"].ToString();
                s.id = Convert.ToInt32(result.Rows[i]["id"]);
                s.codigo = (result.Rows[i]["codigo"].ToString());


            }
            return s;
        }



        public List<Modelo.Apuesta> informacionApuestas(string codigoSorteo)
        {
            Modelo.Persona p = new Modelo.Persona();
            List<Modelo.Persona> lista = new List<Modelo.Persona>();
            List<Modelo.Apuesta> listaPuestas = new List<Modelo.Apuesta>();
            Modelo.Sorteo s = new Modelo.Sorteo();
            s = buscarInfoSorteo(codigoSorteo);
            DataTable result = new DataTable();
            result = apuesta.SelectApuesta(s.id);
            
            for (int i = 0; i < result.Rows.Count; i++)
            {

                Modelo.Apuesta ap = new Modelo.Apuesta();

                ap.id = Convert.ToInt32(result.Rows[i]["id"]);
                ap.id_persona = Convert.ToInt32(result.Rows[i]["id_persona"]);
                ap.id_sorteo = Convert.ToInt32(result.Rows[i]["id_sorteo"]);
                ap.numero = Convert.ToInt32(result.Rows[i]["numero"]);
                ap.monto = Convert.ToInt32(result.Rows[i]["monto_apostado"]);

                listaPuestas.Add(ap);


            }


            return listaPuestas;
        }

        public void informacionPersonaConNumero(string codigoSorteo, int numUno, int numDos, int numtres)
        {
           
            List<Modelo.Apuesta> listaGeneral = new List<Modelo.Apuesta>();
            List<Modelo.Apuesta> listaUno = new List<Modelo.Apuesta>();
            List<Modelo.Apuesta> listaDos = new List<Modelo.Apuesta>();
            List<Modelo.Apuesta> listaTres = new List<Modelo.Apuesta>();

            listaGeneral = informacionApuestas(codigoSorteo);
           
            for (int i = 0; i < listaGeneral.Count; i++)
            {
               if(listaGeneral[i].numero == numUno)
                {
                    listaUno.Add(listaGeneral[i]);
                    
                }else if(listaGeneral[i].numero == numDos)
                {
                    listaDos.Add(listaGeneral[i]);
                }
                else if (listaGeneral[i].numero == numtres)
                {
                    listaTres.Add(listaGeneral[i]);
                }
            }
            BuscarYenviarCorreo(listaUno);
            BuscarYenviarCorreo(listaDos);
            BuscarYenviarCorreo(listaTres);
            


            
        }


        public Modelo.Persona BuscarPersona(int id)
        {
            Modelo.Persona p = new Modelo.Persona();
            DataTable result = new DataTable();
            result = persona.SelectPorId(id);
            for (int i = 0; i < result.Rows.Count; i++)
            {
                p.id = Convert.ToInt32(result.Rows[i]["id"]);
                p.cedula = result.Rows[i]["cedula"].ToString();
                p.nombre = result.Rows[i]["nombre"].ToString();
                p.apellido = result.Rows[i]["apellido"].ToString();
                p.correo = result.Rows[i]["correo"].ToString();
                p.contrasenna = result.Rows[i]["contrasenna"].ToString();
                p.privilegios = Convert.ToBoolean(result.Rows[i]["privilegios"]);
            }
            
                return p;

        }

        public void BuscarYenviarCorreo(List<Modelo.Apuesta> lista)
        {
            Modelo.Persona p = new Modelo.Persona();
            for (int i = 0; i < lista.Count; i++)
            {
               p = BuscarPersona(lista[i].id_persona);
                not.enviarCorreo(p.correo);

            }
        }
        
    }
    }

