using StrategyPattern.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Business.Strategies.Imposto
{
    public interface IImpostoStrategy
    {
        public decimal GetTaxaPara(Pedido pedido);
    }
}
