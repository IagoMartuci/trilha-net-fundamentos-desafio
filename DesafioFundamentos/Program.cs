using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0.0M;
decimal precoPorHora = 0.0M;

string precoInicialString;
string precoPorHoraString;

do
{
    Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                    "Digite o preço inicial:");
    precoInicialString = Estacionamento.ValidarValorNumerico(Console.ReadLine());
    precoInicial = Estacionamento.ConverterParaDecimal(precoInicialString);


    Console.WriteLine("Agora digite o preço por hora:");
    precoPorHoraString = Estacionamento.ValidarValorNumerico(Console.ReadLine());
    precoPorHora = Estacionamento.ConverterParaDecimal(precoPorHoraString);

    if (precoInicialString.Contains("inválido") || precoPorHoraString.Contains("inválido"))
        Console.WriteLine("Valores inválidos. Por favor, revise os preços informados.\n");

} while (precoInicialString.Contains("inválido") || precoPorHoraString.Contains("inválido"));

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

//string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Alterar veículos");
    Console.WriteLine("5 - Encerrar");
    //opcao = Console.ReadLine();
    //switch(opcao)
    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            es.AlterarVeiculos();
            break;

        case "5":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");