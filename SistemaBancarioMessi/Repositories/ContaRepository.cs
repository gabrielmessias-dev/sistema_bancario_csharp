using SistemaBancarioMessi.Models;

namespace SistemaBancarioMessi.Repositories;
public class ContaRepository : IContaRepository
{
    // static: A lista pertence à classe, não à instância. 
    // Todos os 'new ContaRepository()' enxergam a mesma lista.
    private static List<Conta> _contas = new List<Conta>();

    public void CriarConta(Conta conta)
    {
        _contas.Add(conta);
    }

    public Conta? ProcurarPorNumero(int numero)
    {
        // Retorna a primeira conta que bater o número ou null
        return _contas.FirstOrDefault(c => c.Numero == numero);
    }

    public List<Conta> ListarTodas()
    {
        return _contas;
    }

    public void AtualizarConta(Conta conta)
    {
        // Como estamos usando memória (List), o objeto já é atualizado por referência.
        // Se fosse Banco de Dados SQL, aqui teria um comando "UPDATE Contas SET Saldo = ..."
        var contaExistente = ProcurarPorNumero(conta.Numero);
        if (contaExistente != null)
        {
            var index = _contas.IndexOf(contaExistente);
            _contas[index] = conta;

            Console.WriteLine("Conta atualizada no repositório!");
        }
    }

    public void Deletar(int numero)
    {
        var conta = ProcurarPorNumero(numero);
        if (conta != null)
        {
            _contas.Remove(conta);
        }
    }

}
