using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiempos.Controladores
{
   public class Serial
    {
        String serial;
        int contador;
        int cont = 0;
        char[] letras = { 'A', 'B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z','1','2','3','4','5','6','7','8','9' };


        public String sacarSerial()
        {
            Random rnd = new Random();

            do
            {
                for (int i = 0; i < letras.Length; i++)
                {
                    contador++;
                    int rand = rnd.Next(0, 33);
                    serial += letras[rand];


                    if (contador == 4)
                    {
                        if (cont == 0)                       {
                            return serial;
                            break;
                        }
                        else
                        {
                            serial += "-";
                            cont++;
                            contador = 0;
                        }
                    }

                }
            } while (cont == 4);
            {
                return "";

            }
        }
    }
}
