using SistemaBancarioMessi.Models;
using SistemaBancarioMessi.Repositories;
namespace SistemaBancarioMessi.Controllers;

internal class ContaController
{
    // Instancia o Repositório para ter acesso à lista de contas
    private readonly ContaRepository _contaRepository = new ContaRepository();

    // Variável para gerar números automáticos
    private int _numeroAtual = 0;

    // CRUD
    public void CadastrarConta(int tipo, string titular, decimal saldoInicial)
    {
        _numeroAtual++;
        Conta novaConta = null;

        // Polimorfismo - Cria o tipo específico, mas guarda na variável genérica "Conta" 
        switch (tipo)
        {
            case 1: // Conta Corrente
                novaConta = new ContaCorrente(_numeroAtual, titular, saldoInicial);
                break;
            case 2: // Conta Poupança
                novaConta = new ContaPoupanca(_numeroAtual, titular, saldoInicial);
                break;
            case 3: // Conta Empresarial com limite padrão de 1000
                novaConta = new ContaEmpresarial(_numeroAtual, titular, saldoInicial, 1000m);
                break;
            default:
                Console.WriteLine("Tipo de conta inválido!");
                return;
        }

        _contaRepository.CriarConta(novaConta);
        Console.WriteLine($"\nConta tipo {tipo} criada com sucesso! Número: {novaConta.Numero}");
    }

    public void ListarTodas()
    {
        var contas = _contaRepository.ListarTodas();

        if (contas.Count == 0)
        {
            Console.WriteLine("\nNão há contas cadastradas.");
            return;
        }

        foreach (var conta in contas)
        {
            Console.WriteLine($"Número: {conta.Numero} | Titular: {conta.Titular} | Saldo: {conta.Saldo:C}");
        }
    }

    public void ProcurarPorNumero(int numero)
    {
        var conta = _contaRepository.ProcurarPorNumero(numero);

        if (conta != null)
        {
            Console.WriteLine($"\nEncontrada: Conta {conta.Numero} - {conta.Titular} - Saldo: {conta.Saldo:C}");
        }
        else
        {
            Console.WriteLine($"\nConta número {numero} não encontrada.");
        }
    }

    // Métodos Financeiros
    public void Sacar(int numero, decimal valor)
    {
        var conta = _contaRepository.ProcurarPorNumero(numero);

        if (conta == null)
        {
            Console.WriteLine("Conta não encontrada.");
            return;
        }

        try
        {
            // O Controller manda a ordem. Se for ContaCorrente, a Model cobra taxa. Se for Empresarial, usa limite.
            conta.Sacar(valor);

            Console.WriteLine($"Saque realizado! Novo saldo: {conta.Saldo:C}");
        }
        catch (Exception e)
        {
            // Captura o erro "Saldo Insuficiente" que criamos na Model
            Console.WriteLine($"Erro no saque: {e.Message}");
        }
    }

    public void Depositar(int numero, decimal valor)
    {
        var conta = _contaRepository.ProcurarPorNumero(numero);

        if (conta != null)
        {
            conta.Depositar(valor);
            Console.WriteLine($"Depósito realizado! Novo saldo: {conta.Saldo:C}");
        }
        else
        {
            Console.WriteLine("Conta não encontrada.");
        }
    }

    public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
    {
        var contaOrigem = _contaRepository.ProcurarPorNumero(numeroOrigem);
        var contaDestino = _contaRepository.ProcurarPorNumero(numeroDestino);

        if (contaOrigem != null && contaDestino != null)
        {
            try
            {
                // A classe pai Conta sabe como transferir
                contaOrigem.Transferir(contaDestino, valor);
                Console.WriteLine("Transferência realizada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro na transferência: {e.Message}");
            }
        }
        else
        {
            Console.WriteLine("Conta de origem ou destino não encontrada.");
        }
    }

    // Método Especial da ContaEmpresarial
    public void PedirEmprestimo(int numero, decimal valor)
    {
        var conta = _contaRepository.ProcurarPorNumero(numero);

        if (conta == null)
        {
            Console.WriteLine("Conta não encontrada.");
            return;
        }

        if (conta is ContaEmpresarial contaEmpresarial)
        {
            try
            {
                contaEmpresarial.PedirEmprestimo(valor);
                Console.WriteLine($"Empréstimo concedido! Novo saldo: {contaEmpresarial.Saldo:C}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            // Se for ContaCorrente ou Poupanca, cai aqui
            Console.WriteLine("Operação inválida: Apenas Contas Empresariais podem pedir empréstimo.");
        }
    }

    public void AtualizarConta(int numero, string novoTitular)
    {
        // Busca a conta na lista
        var conta = _contaRepository.ProcurarPorNumero(numero);

        if (conta != null)
        {
            // Altera apenas o Titular
            conta.Titular = novoTitular;
            _contaRepository.AtualizarConta(conta);

            Console.WriteLine($"\nSucesso! O titular da conta {numero} agora é: {conta.Titular}");
        }
        else
        {
            Console.WriteLine("\nConta não encontrada para atualização.");
        }
    }

    public void DeletarConta(int numero)
    {
        // Verifica se existe
        var conta = _contaRepository.ProcurarPorNumero(numero);

        if (conta != null)
        {
            _contaRepository.Deletar(numero);
            Console.WriteLine($"\nConta número {numero} deletada com sucesso!");
        }
        else
        {
            Console.WriteLine("\nConta não encontrada.");
        }
    }
}