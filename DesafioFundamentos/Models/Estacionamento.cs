namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0.0M;
        private decimal precoPorHora = 0.0M;
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

            if (!veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                veiculos.Add(placa.ToUpper());
            else
                Console.WriteLine("A placa informada já possui um veículo com o cadastrato ativo");
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

                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal.ToString("0.00")}");
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

                // Alterando a placa através do índice
                int index = veiculos.IndexOf(placa);
                veiculos[index] = novaPlaca;

                Console.WriteLine("Placa" + placa + " alterada com sucesso. Nova placa: " + novaPlaca);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        // MÉTODOS PARA VALIDAÇÃO DOS VALORES INFORMADOS COMO PREÇO

        // MODELO 1:

        public static string ValidarValorNumerico(string strValor)
        {
            decimal decimalValor;

            // Quando fizer o TryParse, se for true é porque o valor é númerico
            bool isNumber = decimal.TryParse(strValor, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out decimalValor);

            if (isNumber)
            {
                // Retorna a mesma string, já que ela é true para número
                // Depois trabalhamos a conversão dessa string para decimal no método específico.
                return strValor;
            }
            else
            {
                // Se colocar o Console.WriteLine da erro por conta do tipo de retorno do método
                // Error #CS0029 "cannot implicitly convert type 'void' to 'string' 
                return $"O preço {strValor} é inválido!";
            }
        }

        public static decimal ConverterParaDecimal(string strValor)
        {
            decimal decimalValor;

            // Verifica se a string de valor contém ponto, se for true, substitui o ponto por vírgula
            if (strValor.Contains("."))
                strValor = strValor.Replace('.', ',');

            if (decimal.TryParse(strValor, out decimalValor))
                return decimalValor;
            else
                return 0;
        }

        // MODELO 2

        //public static string ValidarValorNumerico(string strValor)
        //{
        //    decimal decimalValor;

        //    // Verifica se a string de valor contém ponto, se for true, substitui o ponto por vírgula
        //    if (strValor.Contains("."))
        //        strValor = strValor.Replace('.', ',');

        //    // Quando fizer o TryParse, se for true é porque o valor é númerico
        //    bool isNumber = decimal.TryParse(strValor, System.Globalization.NumberStyles.Any,
        //        System.Globalization.NumberFormatInfo.InvariantInfo, out decimalValor);

        //    if (isNumber)
        //    {
        //        return strValor;
        //    }
        //    else
        //    {
        //        // Se colocar o Console.WriteLine da erro por conta do tipo de retorno do método
        //        // Error #CS0029 "cannot implicitly convert type 'void' to 'string' 
        //        return $"O preço {strValor} é inválido!";
        //    }
        //}

        //public static decimal ConverterParaDecimal(string strValor)
        //{
        //    decimal decimalValor;

        //    if (decimal.TryParse(strValor, out decimalValor))
        //        return decimalValor;

        //    return 0;
        //}
    }
}