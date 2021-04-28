using StrategyPattern.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Business.Strategies.Fatura
{
    public interface IFatura
    {
        public void Gerador(Pedido pedido);
    }
}
