using System.Text.RegularExpressions;

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
            // Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string veiculo = Console.ReadLine();

            if (Regex.IsMatch(veiculo, @"[A-Z]{3}-[0-9]{4}$", RegexOptions.IgnoreCase) || Regex.IsMatch(veiculo, @"[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$", RegexOptions.IgnoreCase)) 
            {  
                if (veiculos.Any(x => x.ToUpper() == veiculo.ToUpper()))
                {
                Console.WriteLine("Erro, esse veículo já está estacionado aqui. Confira se digitou a placa corretamente");
                }
                else
                {
                veiculos.Add(veiculo);
                Console.WriteLine("Veiculo cadastrado com sucesso!");
                }
                
            }
            else
            {
                Console.WriteLine("A placa informada é inválida, por favor informe uma placa no modelo ABC-1234 ou no modelo Mercosul ABC1D23");
            }
           
        }


        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // Realizar o seguinte cálculo do valorTotal                
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas; 

                // Remover a placa digitada da lista de veículos
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui ou a placa é inválida. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {

            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Exibir os veículos estacionados
                int countForeach = 1;
                foreach(string placaVeiculo in veiculos)
                {
                    Console.WriteLine($"Veículo nº {countForeach} - Placa {placaVeiculo}");
                    countForeach++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
