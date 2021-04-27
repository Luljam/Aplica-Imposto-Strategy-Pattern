using StrategyPattern.Business.Strategies.Imposto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Business.Models
{
    public class Pedido
    {
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();
        public IList<Pagamento> PagamentosSelecionados { get; } = new List<Pagamento>();
        public IList<Pagamento> PagamentosFinalizados { get; } = new List<Pagamento>();
        public decimal QuantiaDevida => ValorTotal - PagamentosFinalizados.Sum(pagamento => pagamento.Amount);
        public decimal ValorTotal => LineItems.Sum(item => item.Key.Valor * item.Value);
        public StatusEnvio StatusEnvio { get; set; } = StatusEnvio.AguardandoPorPagamento;
        public DetalhesEnvio DetalhesEnvio { get; set; }


        // Implementação Strategy
        public IImpostoStrategy ImpostoStrategy { get; set; }
        public decimal GetTaxa()
        {
            // Com Strategy
            if (ImpostoStrategy == null)
            {
                return 0m;
            }
            return ImpostoStrategy.GetTaxaPara(this);




            // Criar uma Interface que fara o contrato com as classes de imposto para cada país
            // IImpostoStrategy
            // SueciaImpostoStrategy
            // USAImpostoStrategy


            // Como era sem o padrão strategy
            /*
              
            var destino = DetalhesEnvio.PaisDestino.ToLowerInvariant();
            if (destino == "suécia")
            {
                if (destino == DetalhesEnvio.PaisOrigem.ToLowerInvariant())
                {
                    return ValorTotal * 0.25m;
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

            if (destino == "us")
            {
                switch (DetalhesEnvio.EstadoDestino.ToLowerInvariant())
                {
                    case "la": return ValorTotal * 0.095m;
                    case "ny": return ValorTotal * 0.04m;
                    case "nyc": return ValorTotal * 0.045m;
                    default: return 0m;
                }
            }
            */

            //return 0;
        }

    }
    public class DetalhesEnvio
    {
        public string Receptor { get; set; }
        public string Endereco1 { get; set; }
        public string Endereco2 { get; set; }
        public string CodigoPostal { get; set; }
        public string PaisOrigem { get; set; }
        public string EstadoOringem { get; set; }
        public string PaisDestino { get; set; }
        public string EstadoDestino { get; set; }
    }

    public enum StatusEnvio
    {
        AguardandoPorPagamento,
        ProntoParaEnvio,
        Enviado
    }

    public enum ProvedorPagamento
    {
        Paypal,
        CreditCard,
        Fatura
    }

    public class Pagamento
    {
        public decimal Amount { get; set; }
        public ProvedorPagamento ProvedorPagamento { get; set; }
    }

    public class Item
    {
        public string Id { get; }
        public string Name { get; }
        public decimal Valor { get; }

        public ItemType ItemType { get; set; }

        public decimal GetTaxa()
        {
            switch (ItemType)
            {
                case ItemType.Service:
                case ItemType.Food:
                case ItemType.Hardware:
                case ItemType.Literature:
                default:
                    return 0m;
            }
        }

        public Item(string id, string name, decimal valor, ItemType tipo)
        {
            Id = id;
            Name = name;
            Valor = valor;
            ItemType = tipo;
        }
    }
    public enum ItemType
    {
        Service,
        Food,
        Hardware,
        Literature
    }
}
