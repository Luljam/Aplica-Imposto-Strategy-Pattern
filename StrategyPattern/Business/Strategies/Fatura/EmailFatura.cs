using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies.Fatura
{
    public class EmailFatura : Fatura
    {
        public override void Gerador(Pedido pedido)
        {
            var body = GerarFaturaTexto(pedido);

            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                NetworkCredential credenciais = new NetworkCredential("lucianofdebrito@gmail.com", " ");
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = credenciais;
                
                MailMessage mail = new MailMessage("lucianofdebrito@gmail.com", "lucianofdebrito@gmail.com")
                {
                    Subject = "Criamos a fatura do seu pedido",
                    Body = body
                };
                client.Send(mail);
            }
        }
    }
}
