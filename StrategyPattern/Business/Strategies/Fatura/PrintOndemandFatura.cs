using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies.Fatura
{
    public class PrintOndemandFatura : IFatura
    {
        public void Gerador(Pedido pedido)
        {
            using (var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(pedido);

                client.BaseAddress = new Uri("https://pluralsight.com"); /// servidor de impressao... mudar

                client.PostAsync("/print-on-demand", new StringContent(content));
            }
        }
    }
}
