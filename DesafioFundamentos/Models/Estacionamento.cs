using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();


        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            while (true)
            {
                Console.WriteLine("Deseja cadastrar um novo veículo? (s/n)");
                string resposta = Console.ReadLine().ToLower();

                if (resposta == "n" || resposta == "sair")
                {
                    break;
                }
                else if (resposta != "s")
                {
                    Console.WriteLine("Resposta inválida. Digite 's' para cadastrar ou 'n' para sair.");
                    continue;
                }

                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string veiculo = Console.ReadLine();
                veiculos.Add(veiculo);
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();
            Console.WriteLine("Placa digitada: " + placa);

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

                Console.WriteLine("O pagamento foi efetuado? (s/n)");
                string pagamentoEfetuado = Console.ReadLine().ToLower();

                if (pagamentoEfetuado == "s")
                {
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido após o pagamento.");
                }
                else
                {
                    Console.WriteLine($"O veículo {placa} não será removido.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
