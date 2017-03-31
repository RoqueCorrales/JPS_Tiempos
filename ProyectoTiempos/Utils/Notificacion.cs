using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiempos.Utils
{
   public class Notificacion
    {

        public Notificacion()
        {
                
        }

        public void enviarCorreo(string correo,int numero,string codigo,double monto)
        {
            string to = correo;
            string from = "jps.utn.cr@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Ganador de Sorteo en los nuevos tiempos UTN.";
            message.Body = "Has resultado favorecido en el sorteo "+codigo+ " con el numero "+numero+" \n el monto ganado es de "+monto +".";
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);


            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("jps.utn.cr@gmail.com", "RealMadrid");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                            ex.ToString());
            }


        }
    }
    
}
