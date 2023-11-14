namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0.00M;
        private decimal precoPorHora = 0.00M;
        private List<string> veiculos = new List<string>();

        // Construtor
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // Implementado!!!!!
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add(placa.ToUpper());
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI* - OK
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                bool validarConversao;

                do
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI* - OK
                    string horasTexto = Console.ReadLine();
                    int horas = 0;

                    // Conversão segura
                    validarConversao = int.TryParse(horasTexto, out horas);

                    if (!validarConversao)
                    {
                        Console.WriteLine("Horas informadas em formato inválido, por gentileza informar apenas números.");
                    }
                    else
                    {
                        decimal valorTotal = precoInicial + (precoPorHora * horas);

                        // TODO: Remover a placa digitada da lista de veículos
                        // *IMPLEMENTE AQUI* - OK
                        veiculos.Remove(placa);

                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    }
                } while (!validarConversao);

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
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI* - OK
                foreach (string placa in veiculos)
                    Console.WriteLine(placa);

                Console.WriteLine("Total de veículos cadastrados atualmente: " + veiculos.Count);
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void AlterarVeiculos() // TESTE (https://stackoverflow.com/questions/41983796/update-an-item-in-the-list-not-working)
        {
            Console.WriteLine("Digite a placa do veículo para alterar:");

            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine($"Digite a \"nova\" placa para o veículo {placa}:");
                string novaPlaca = Console.ReadLine();

                int index = veiculos.IndexOf(placa);
                veiculos[index] = novaPlaca;

                Console.WriteLine("Placa" + placa + " alterada com sucesso. Nova placa: " + novaPlaca);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }

        }
    }
}
