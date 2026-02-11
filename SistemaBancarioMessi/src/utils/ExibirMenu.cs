namespace SistemaBancarioMessi.src.utils;

internal class ExibirMenu
{
    public void MostrarMenu()
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
    }
}