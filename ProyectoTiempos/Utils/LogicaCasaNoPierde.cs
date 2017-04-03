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
        private double montoQuePuedeApostar;
        private Modelo.Casa casa;

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
            casa = new Modelo.Casa();
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

     

        public double PrimerosNumerosConMasMonto(int id_sorteo)
        {
            DataTable result = new DataTable();
            Modelo.Apuesta apuesta = new Modelo.Apuesta();
            double primero = 0;
            double segundo = 0;
            double tercero = 0;
            double total = 0;
            int cont = 0;

            result = apuesta.SelectMontoDescendente(id_sorteo);
            if (result.Rows.Count != 0)
            {

                for (int i = 0; i < result.Rows.Count; i++)
                {
                    cont++;
                    if (cont ==1)
                    {
                        primero = Convert.ToDouble(result.Rows[i]["sum"])*60;
                    }else if (cont ==2)
                    {
                        segundo = Convert.ToDouble(result.Rows[i]["sum"])*10;
                    }else if (cont ==3)
                    {
                        tercero = Convert.ToDouble(result.Rows[i]["sum"])*5;
                    }

                }
                total = primero + segundo + tercero;

                return total;
            }

            return total;
          

           
        }

        public Boolean DejarApuesta(int numero , int sorteo , double monto)
        {
            DataTable result = new DataTable();
            Modelo.Apuesta apuesta = new Modelo.Apuesta();
            result = casa.SelectDineroCasa();
            int total = 0;

            double dineroCasa = Convert.ToDouble(result.Rows[0]["dinero"]);
            result =apuesta.SelectSumaMontoNumero(numero ,sorteo);

            try
            {
                total = Convert.ToInt32(result.Rows[0]["sum"]);
            }
            catch (Exception e)
            {
                total = 0;
            }
            this.montoQuePuedeApostar = (monto + total ) * 60;
            if (montoQuePuedeApostar > dineroCasa)
            {
                return false;
            }
            return true;
        }

        public double ApuestaMaxima()
        {
            DataTable result = new DataTable();
            Modelo.Apuesta apuesta = new Modelo.Apuesta();
           
            result = casa.SelectDineroCasa();
            double dineroCasa = Convert.ToDouble(result.Rows[0]["dinero"]);
            double total;
            total = montoQuePuedeApostar;

            while (true)
            {
                if (total*60>dineroCasa)
                {
                    total = total / 60;
                }
                if (total*60<=dineroCasa)
                {
                   break;
                }
                
            }
         
            return total*60;
        }

        public double SumaTotalApuestas(int id_sorteo)
        {
            Modelo.Apuesta apuesta = new Modelo.Apuesta();
            Modelo.Sorteo sorteo = new Modelo.Sorteo();
            DataTable result = new DataTable();
            result = sorteo.SelectSorteosEstadoTrue();
            List<Int32> sorteos = new List<int>();

            for (int i = 0; i < result.Rows.Count; i++)
            {
                sorteos.Add(Convert.ToInt32(result.Rows[i]["id"]));
            }
            sorteos.Remove(id_sorteo);

            double a = 0; 

            for (int i = 0; i < sorteos.Count; i++)
            {
               a +=  PrimerosNumerosConMasMonto(sorteos[i]);
            }
            return a;
        }

        public double SorteoTrabajado(int id_sorteo,int numero,double monto)
        {
            Modelo.Apuesta apuesta = new Modelo.Apuesta();
            DataTable result = new DataTable();
            result = apuesta.SelectMontoDescendente(id_sorteo);
            List<Int32> montos = new List<int>();
            double primero;
            double segundo;
            double terceroo;
            double total = 0;
            if (result.Rows.Count == 0)
            {
              return  total = monto * 60;
            }
            if (result.Rows.Count == 1)
            {
                primero = Convert.ToDouble(result.Rows[0]["sum"]);

                if (primero < monto)
                {
                   return total = (monto * 60) + (primero * 10);
                }
                
            }
            else if (result.Rows.Count == 2)
            {
                primero = Convert.ToDouble(result.Rows[0]["sum"]);
                segundo = Convert.ToDouble(result.Rows[1]["sum"]);

                if (primero < monto && segundo < monto)
                {
                   total = (monto * 60) + (primero * 10) + (segundo * 5);
                }
                else if (primero > monto && segundo < monto)
                {
                   total = (primero * 60) + (monto * 10) + (segundo * 5);
                }else
                {
                    total = (primero * 60) + (segundo * 10) + (monto * 5);
                }

                return total;


            }
            if (result.Rows.Count >= 2)
            {

                primero = Convert.ToDouble(result.Rows[0]["sum"]);
                segundo = Convert.ToDouble(result.Rows[1]["sum"]);
                terceroo = Convert.ToDouble(result.Rows[2]["sum"]);

                for (int i = 0; i < result.Rows.Count; i++)
                {


                    if (Convert.ToInt32(result.Rows[i]["numero"]) == numero)
                    {
                        monto = Convert.ToDouble(result.Rows[i]["sum"]) + monto;
                        if (primero < monto)
                        {
                            primero = monto;
                        }
                        else if (segundo < monto)
                        {
                            segundo = monto;
                        }
                        else if (terceroo < monto)
                        {
                            terceroo = monto;
                        }
                    }
                    else
                    {
                        List<Double> listaMontos = new List<double>();
                        listaMontos.Add(primero);
                        listaMontos.Add(segundo);
                        listaMontos.Add(terceroo);
                        listaMontos.Add(monto);

                        listaMontos.Sort();
                        listaMontos.Reverse();

                        primero = listaMontos[0];
                        segundo = listaMontos[1];
                        terceroo = listaMontos[2];
                    }


                }

                primero = primero * 60;
                segundo = segundo * 10;
                terceroo = terceroo * 5;
                total = primero + segundo + terceroo;
                return total;
            }
            return total;
                
           
        }

        public Boolean PermisoApuesta(int id_sorteo , int numero , double monto)
        {
            double total;
            DataTable result = new DataTable();

            result = casa.SelectDineroCasa();
            double dineroCasa = Convert.ToDouble(result.Rows[0]["dinero"]);
            double dineroT = SumaTotalApuestas(id_sorteo);
            total = (dineroCasa + monto)- dineroT;
            double b = SorteoTrabajado(id_sorteo, numero, monto) ;
            if (total-b>=0)
            {
                return true;
            }
            return false;
        }
    }
}
