using SistemaBancarioMessi.src.controller;
using SistemaBancarioMessi.src.model;
using SistemaBancarioMessi.src.repository;
using SistemaBancarioMessi.src.utils;

ExibirMenu();

do
{
    Console.WriteLine("Bem-vindo ao Sistema Bancário Messi!");
    Console.WriteLine("1. Listar todas as contas");
    Console.WriteLine("2. Buscar conta por número");
    Console.WriteLine("3. Atualizar dados da conta");
    Console.WriteLine("4. Apagar conta");
    Console.WriteLine("5. Sacar");
    Console.WriteLine("6. Depositar");
    Console.WriteLine("7. Transferir valores entre contas");
    Console.WriteLine("8. Criar uma nova conta");
    Console.WriteLine("9. Sair do aplicativo");
    Console.Write("Escolha uma opção: ");
    int opcao = int.Parse(Console.ReadLine()!);
    switch (opcao)
    {
        case 1:
            ListarTodasAsContas();
            break;
        case 2:
            BuscarContaPorNumero();
            break;
        case 3:
            AtualizarDadosConta();
            break;
        case 4:
            ApagarConta();
            break;
        case 5:
            Sacar();
            break;
        case 6:
            Depositar();
            break;
        case 7:
            Transferir();
            break;
        case 8:
            CriarNovaConta();
            break;
        case 9:
            Console.WriteLine("Saindo do aplicativo. Obrigado por usar o Sistema Bancário Messi!");
            break;
        default:
            Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
            break;

    }
} while (true);