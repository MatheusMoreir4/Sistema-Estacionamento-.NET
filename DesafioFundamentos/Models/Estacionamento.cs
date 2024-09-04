using System.ComponentModel;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placaEntrada = Console.ReadLine();
            var veiculo = new Veiculo();
            veiculo.Placa=placaEntrada;
            veiculo.Entrada=DateTime.Now;
            veiculos.Add(veiculo);
            Console.WriteLine($"Placa {placaEntrada} adicionada com Sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            
            string placaSaida = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.Placa.ToUpper() == placaSaida.ToUpper()))
            {
                var veiculo = veiculos.Last(x=> x.Placa.ToUpper() == placaSaida.ToUpper());
                veiculo.Saida = DateTime.Now;
               
                var totalHora = (DateTime.Now - veiculo.Entrada).TotalSeconds/60/60;
                Console.WriteLine("A Quantidade de Horas que você Permaneceu:  "+ totalHora.ToString("0.##"));            

                var valorTotal = precoInicial + ((decimal)totalHora * precoPorHora);
                Console.WriteLine($"O veículo {veiculo.Placa} foi removido e o preço total foi de: R$ {valorTotal.ToString("0.##")}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(var veiculo in veiculos)
                {
                    if (veiculo.Saida == null)
                    Console.WriteLine(veiculo.Placa);
                }
                
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
