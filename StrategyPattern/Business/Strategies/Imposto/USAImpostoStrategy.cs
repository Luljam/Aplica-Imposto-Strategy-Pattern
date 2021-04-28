using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies.Imposto
{
    public class USAImpostoStrategy : IImpostoStrategy
    {
        public decimal GetTaxaPara(Pedido pedido)
        {
            switch (pedido.DetalhesEnvio.EstadoDestino.ToLowerInvariant())
            {
                case "la": return pedido.ValorTotal * 0.095m;
                case "ny": return pedido.ValorTotal * 0.04m;
                case "nyc": return pedido.ValorTotal * 0.045m;
                default: return 0m;
            }
        }
    }
}
