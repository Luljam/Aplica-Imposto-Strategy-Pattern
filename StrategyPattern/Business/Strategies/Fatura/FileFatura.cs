using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies.Fatura
{
    public class FileFatura : Fatura
    {
        public override void Gerador(Pedido pedido)
        {
            string path = @"c:\Temp\";
            string caminho = $"fatura_{Guid.NewGuid()}.txt";

            using (var stream = new StreamWriter(path + caminho))
            {
                stream.Write(GerarFaturaTexto(pedido));
                stream.Flush();
            }
        }
    }
}
