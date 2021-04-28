using StrategyPattern.Business.Models;
using StrategyPattern.Business.Strategies.Fatura;
using StrategyPattern.Business.Strategies.Imposto;
using System;

namespace StrategyPattern
{
    class Program
    {
        // implementando Strategy
        // A idéia é desacoplae código por responsabilidade de função e manter um código mais limpo
        // Poder fazer uso de testes unitários
        // Definir strategy especifica de imposto para ter certesa que sempre quer criarmos o pedido definiremos a estrategia
        static void Main(string[] args)
        {
            var pedido = new Pedido
            {
                DetalhesEnvio = new DetalhesEnvio
                {
                    PaisOrigem = "suécia",
                    PaisDestino = "suécia"
                }

            };


            //var destino = pedido.DetalhesEnvio.PaisDestino.ToLowerInvariant();
            //if (destino == "suécia")
            //{
            //    pedido.ImpostoStrategy = new SueciaImpostoStrategy();
            //}
            //else if(destino == "us")
            //{
            //    pedido.ImpostoStrategy = new USAImpostoStrategy();
            //}


            pedido.LineItems.Add(
                    new Item("CSHARP_SMORGASBORD",
                    "C# Smorgasbord",
                    100m,
                    ItemType.Literature),
                    1);

            pedido.LineItems.Add(
                    new Item("CONSULTING",
                        "Building a website",
                        100m,
                        ItemType.Service),
                    1);

            pedido.PagamentosSelecionados.Add(new Pagamento { ProvedorPagamento = ProvedorPagamento.Fatura });

            Console.WriteLine("Taxa: $" + pedido.GetTaxa(new SueciaImpostoStrategy()));

            //pedido.Fatura = new FileFatura();
            pedido.Fatura = new EmailFatura();
            pedido.FinalizarPedido();
            Console.ReadLine();
        }
    }
}
