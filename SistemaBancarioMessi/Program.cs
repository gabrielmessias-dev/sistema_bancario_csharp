using SistemaBancarioMessi.Controllers;

namespace SistemaBancarioMessi;

class Program
{
    static void Main(string[] args)
    {
        // Instancia o Controller, ele já cria o Repositório internamente.
        ContaController controller = new ContaController();

        int opcao = 0;

        // Loop Principal
        while (true)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("*****************************************************");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                SISTEMA BANCÁRIO MESSI               ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("                                                     ");
            Console.WriteLine("            1 - Criar Conta                          ");
            Console.WriteLine("            2 - Listar todas as Contas               ");
            Console.WriteLine("            3 - Buscar Conta por Numero              ");
            Console.WriteLine("            4 - Atualizar Dados da Conta             ");
            Console.WriteLine("            5 - Apagar Conta                         ");
            Console.WriteLine("            6 - Sacar                                ");
            Console.WriteLine("            7 - Depositar                            ");
            Console.WriteLine("            8 - Transferir valores entre Contas      ");
            Console.WriteLine("            9 - Sair                                 ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("*****************************************************");
            Console.Write("Entre com a opção desejada: ");

            // Tratamento simples para não quebrar se digitar letra
            try
            {
                opcao = int.Parse(Console.ReadLine()!);
            }
            catch
            {
                opcao = 0; // Opção inválida
            }

            if (opcao == 9)
            {
                Console.WriteLine("\nSaindo do sistema... Até logo!");
                break;
            }

            // 3. Switch Case: Redireciona para a lógica correta
            switch (opcao)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nCriar Conta");

                    Console.Write("Digite o número do tipo (1-Corrente, 2-Poupança, 3-Empresarial): ");
                    int tipo = int.Parse(Console.ReadLine()!);

                    Console.Write("Digite o Nome do Titular: ");
                    string titular = Console.ReadLine()!;

                    Console.Write("Digite o Saldo Inicial: ");
                    decimal saldo = decimal.Parse(Console.ReadLine()!);

                    // Chama o Controller passando os dados crus
                    controller.CadastrarConta(tipo, titular, saldo);
                    KeyPress();
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nListar todas as Contas");
                    controller.ListarTodas();
                    KeyPress();
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nBuscar Conta por Número");
                    Console.Write("Digite o número da conta: ");
                    int numeroBusca = int.Parse(Console.ReadLine()!);
                    controller.ProcurarPorNumero(numeroBusca);
                    KeyPress();
                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nAtualizar Dados da Conta");

                    Console.Write("Digite o número da conta que deseja atualizar: ");
                    int numAtualizar = int.Parse(Console.ReadLine()!);

                    Console.Write("Digite o Novo Nome do Titular: ");
                    string novoNome = Console.ReadLine()!;

                    controller.AtualizarConta(numAtualizar, novoNome);
                    KeyPress();
                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nApagar Conta");

                    Console.Write("Digite o número da conta que deseja apagar: ");
                    int numApagar = int.Parse(Console.ReadLine()!);

                    // Confirmação simples por segurança
                    Console.Write("Tem certeza? (S/N): ");
                    string confirmacao = Console.ReadLine()!.ToUpper();

                    if (confirmacao == "S")
                    {
                        controller.DeletarConta(numApagar);
                    }
                    else
                    {
                        Console.WriteLine("Operação cancelada.");
                    }

                    KeyPress();
                    break;

                case 6:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nSacar");
                    Console.Write("Digite o número da conta: ");
                    int numeroSaque = int.Parse(Console.ReadLine()!);

                    Console.Write("Digite o valor do saque: ");
                    decimal valorSaque = decimal.Parse(Console.ReadLine()!);
                    controller.Sacar(numeroSaque, valorSaque);
                    KeyPress();
                    break;

                case 7:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nDepositar");
                    Console.Write("Digite o número da conta: ");
                    int numeroDeposito = int.Parse(Console.ReadLine()!);

                    Console.Write("Digite o valor do depósito: ");
                    decimal valorDeposito = decimal.Parse(Console.ReadLine()!);

                    controller.Depositar(numeroDeposito, valorDeposito);
                    KeyPress();
                    break;

                case 8:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nTransferir entre Contas");
                    Console.Write("Digite o número da conta de ORIGEM: ");
                    int origem = int.Parse(Console.ReadLine()!);

                    Console.Write("Digite o número da conta de DESTINO: ");
                    int destino = int.Parse(Console.ReadLine()!);

                    Console.Write("Digite o valor da transferência: ");
                    decimal valorTransferencia = decimal.Parse(Console.ReadLine()!);

                    controller.Transferir(origem, destino, valorTransferencia);
                    KeyPress();
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpção Inválida!");
                    KeyPress();
                    break;
            }
        }
    }

    static void KeyPress()
    {
        Console.ResetColor();
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}