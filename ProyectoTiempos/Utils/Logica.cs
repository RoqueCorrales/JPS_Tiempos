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
        private Apuesta apues;
        private Notificacion not;
        private SorteoPremiado sorPre;
        private Casa casa;
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
            apues = new Apuesta();
            casa = new Casa();
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


        public List<string> cargarComboSorteos()
        {
            DataTable result = new DataTable();

            result = this.sorteo.SelectCodigo();
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


        public List<String> cargarComboxSorteosNoPremiadosParaFrmNumpremiados()
        {

            DataTable todos = new DataTable();
            DataTable resultPremiados = new DataTable();

            todos = sorteo.SelectSorteosEstadoFalse();
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
                double monto = 0;
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
            BuscarYenviarCorreo(listaUno,numUno,codigoSorteo,60);
            BuscarYenviarCorreo(listaDos,numDos,codigoSorteo,10);
            BuscarYenviarCorreo(listaTres,numtres,codigoSorteo,5);
            


            
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

        public void BuscarYenviarCorreo(List<Modelo.Apuesta> lista, int numero, string codigo, int premio)
        {
            Modelo.Persona p = new Modelo.Persona();
            double montosPagados = 0;
            for (int i = 0; i < lista.Count; i++)
            {
               p = BuscarPersona(lista[i].id_persona);

                double monto = 0;
                monto = lista[i].monto * premio;
                montosPagados = montosPagados + monto;
                not.enviarCorreo(p.correo,numero,codigo,monto);
                cargarCasa(montosPagados);

            }
            
        }


        private void cargarCasa(double montoPagar)
        {
            double dinero = 0;
            string nombre = "";
            int id =0;
            DataTable result = new DataTable();
            result = casa.Select();
            for (int i = 0; i < result.Rows.Count; i++)
            {
                id = Convert.ToInt32(result.Rows[i]["id"]);
                nombre = result.Rows[i]["nombre"].ToString();
                 dinero = Convert.ToDouble(result.Rows[i]["dinero"]);
            }
            montoPagar = dinero - montoPagar;
            casa.Update(id, nombre,montoPagar);
        }

        //************************************Tabla Ganadores *********************************************************

        /*
         * Ir a buscar id del sorteo.
         * Con el id_sorteo buscar los numeros premiados para ese sorteo.
         * Luego hacer una busqueda en la tabla apuestas de apuesta.id_sorteo = id_sorteo && where numero apostado = numUno || where numero apostado = numDos || where numero apostado = numTres  
         * 
         * */
         public DataTable CompletarTablaGanadores(string cod)
        {
            Modelo.SorteoPremiado sPre = new Modelo.SorteoPremiado();
            Modelo.Sorteo s = new Modelo.Sorteo();
            s = buscarInfoSorteo(cod);
            sPre = CargarInfoSorteoPremiado(cod);
            return apues.SelectParaTablaGanadores(s.id);
            
            

        }

        /*
         * Almacenar Numeros premiados para un sorteo.
         * 
         */
         public Modelo.SorteoPremiado CargarInfoSorteoPremiado(string cod)
        {
            DataTable result = new DataTable();
            Modelo.SorteoPremiado sPre = new Modelo.SorteoPremiado();
            result =sorPre.SelectPorCodigo(cod);
            for (int i = 0; i < result.Rows.Count; i++)
            {
                sPre.id = Convert.ToInt32(result.Rows[i]["id"]);
                sPre.numUno = Convert.ToInt32(result.Rows[i]["numerouno"]);
                sPre.numDos = Convert.ToInt32(result.Rows[i]["numerodos"]);
                sPre.numTres = Convert.ToInt32(result.Rows[i]["numerotres"]);
                sPre.id_sorteo = Convert.ToInt32(result.Rows[i]["id_sorteo"]);
                sPre.codigo_sorteo = (result.Rows[i]["codigo_sorteo"]).ToString();
                sPre.pagado = Convert.ToBoolean(result.Rows[i]["pagado"]);
            }
            
            return sPre;
        }
        
        public double pagarMonto(string cod, int numero, double monto)
        {
            Modelo.SorteoPremiado sp = new Modelo.SorteoPremiado();
            DataTable result = new DataTable();
            int uno = 0;
            int dos = 0;
            int tres = 0;
            result = sorPre.SelectPorCodigo(cod);
            for (int i = 0; i < result.Rows.Count; i++)
            {
                uno = Convert.ToInt32(result.Rows[i]["numerouno"]);
                dos = Convert.ToInt32(result.Rows[i]["numerodos"]);
                tres = Convert.ToInt32(result.Rows[i]["numerotres"]);

            }

            if(numero == uno)
            {
                monto = monto * 60;
            }else if( numero == dos)
            {
                monto = monto * 10;
            }else
            {
                monto = monto * 5;
            }
            return monto;
        }
    }
}

