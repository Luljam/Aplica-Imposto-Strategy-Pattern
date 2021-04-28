using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies.Fatura
{
    public abstract class Fatura : IFatura
    {
        public abstract void Gerador(Pedido pedido);

        public string GerarFaturaTexto(Pedido pedido)
        {
            var fatura = $"DATA DA FATURA: { DateTimeOffset.Now}{ Environment.NewLine}";
            fatura += $"ID|NOME|VALOR|QUANTIDADE{Environment.NewLine}";

            foreach (var item in pedido.LineItems)
            {
                fatura += $"{item.Key.Id}|{item.Key.Name}|{item.Key.Valor}|{item.Value}";
            }

            fatura += Environment.NewLine + Environment.NewLine;

            var taxa = pedido.GetTaxa();
            var total = pedido.ValorTotal + taxa;

            fatura += $"TAXA TOTAL: {taxa}{Environment.NewLine}";
            fatura += $"TOTAL: {total}{Environment.NewLine}";

            return fatura;
        }
    }
}
