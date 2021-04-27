using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies.Imposto
{
    public class SueciaImpostoStrategy : IImpostoStrategy
    {
        public decimal GetTaxaPara(Pedido pedido)
        {
            var destino = pedido.DetalhesEnvio.PaisDestino.ToLowerInvariant();

            if (destino == pedido.DetalhesEnvio.PaisOrigem.ToLowerInvariant())
            {
                return pedido.ValorTotal * 0.25m;
            }

            #region
            //if (destino == DetalhesEnvio.PaisOrigem.ToLowerInvariant())
            //{
            //    decimal taxaTotal = 0m;
            //    foreach (var item in LineItems)
            //    {
            //        switch (item.Key.ItemType)
            //        {
            //            case ItemType.Food:
            //                taxaTotal += (item.Key.Valor * 0.06m) * item.Value;
            //                break;
            //            case ItemType.Literature:
            //                taxaTotal += (item.Key.Valor * 0.08m) * item.Value;
            //                break;
            //            case ItemType.Service:
            //            case ItemType.Hardware:
            //                taxaTotal += (item.Key.Valor * 0.25m) * item.Value;
            //                break;
            //        }
            //    }
            //    return taxaTotal;
            //}
            #endregion

            return 0;
        }
    }
}
