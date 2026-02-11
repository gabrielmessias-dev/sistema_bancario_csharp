using SistemaBancarioMessi.src.model;
namespace SistemaBancarioMessi.src.controller;

internal class ContaController
{
    private List<Conta> contas = new();
    int numero = 0;

    // CRUD Conta
    public void CadastrarConta(Conta conta)
    {
        numero++;
        conta.Numero = numero;
        contas.Add(conta);
        Console.WriteLine($"Conta número {conta.Numero} cadastrada com sucesso!");
    }

    public void ProcurarPorNumero(int numero)
    {
        var conta = contas.FirstOrDefault(c => c.Numero == numero);
        if (conta != null)
        {
            Console.WriteLine($"Conta encontrada: Número {conta.Numero}");
        }
        else
        {
            Console.WriteLine($"Conta número {numero} não encontrada.");
        }
    }

    public void ListarTodasAsContas()
    {
        if (contas.Count == 0)
        {
            Console.WriteLine("Nenhuma conta cadastrada.");
            return;
        }
        foreach (var conta in contas)
        {
            Console.WriteLine($"Conta número {conta.Numero}");
        }
    }

    public void AtualizarConta(Conta conta)
    {
        var contaExistente = contas.FirstOrDefault(c => c.Numero == conta.Numero);
        if (contaExistente != null)
        {
            Console.WriteLine($"Conta número {conta.Numero} atualizada com sucesso!");
        }
        else
        {
            Console.WriteLine($"Conta número {conta.Numero} não encontrada.");
        }
    }

    public void ApagarConta(int numero)
    {
        var conta = contas.FirstOrDefault(c => c.Numero == numero);
        if (conta != null)
        {
            contas.Remove(conta);
            Console.WriteLine($"Conta número {numero} apagada com sucesso!");
        }
        else
        {
            Console.WriteLine($"Conta número {numero} não encontrada.");
        }
    }

    // Métodos financeiros
    public void Sacar(int numero, decimal valor)
    {
        var conta = contas.FirstOrDefault(c => c.Numero == numero);
        if (conta != null)
        {
            if (conta.Saldo >= valor)
            {
                conta.Saldo -= valor;
                Console.WriteLine($"Saque de R${valor} realizado com sucesso na conta número {numero}!");
            }
            else
            {
                Console.WriteLine($"Saldo insuficiente para realizar o saque na conta número {numero}.");
            }
        }
        else
        {
            Console.WriteLine($"Conta número {numero} não encontrada.");
        }
    }

    public void Depositar(int numero, decimal valor)
    {
        var conta = contas.FirstOrDefault(c => c.Numero == numero);
        if (conta != null)
        {
            conta.Saldo += valor;
            Console.WriteLine($"Depósito de R${valor} realizado com sucesso na conta número {numero}!");
        }
        else
        {
            Console.WriteLine($"Conta número {numero} não encontrada.");
        }
    }

    public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
    {
        var contaOrigem = contas.FirstOrDefault(c => c.Numero == numeroOrigem);
        var contaDestino = contas.FirstOrDefault(c => c.Numero == numeroDestino);
        if (contaOrigem != null && contaDestino != null)
        {
            if (contaOrigem.Saldo >= valor)
            {
                contaOrigem.Saldo -= valor;
                contaDestino.Saldo += valor;
                Console.WriteLine($"Transferência de R${valor} realizada com sucesso da conta número {numeroOrigem} para a conta número {numeroDestino}!");
            }
            else
            {
                Console.WriteLine($"Saldo insuficiente para realizar a transferência na conta número {numeroOrigem}.");
            }
        }
        else
        {
            Console.WriteLine($"Conta número {numeroOrigem} ou número {numeroDestino} não encontrada.");
        }
    }

    public void Emprestimo(int numero, decimal valor)
    {

    }

}