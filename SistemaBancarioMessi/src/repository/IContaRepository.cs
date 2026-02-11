using SistemaBancarioMessi.src.model;

namespace SistemaBancarioMessi.src.repository;

internal interface IContaRepository
{
    // CRUD Conta
    void BuscarContaPorNumero(int numero);
    void ListarTodasAsContas();
    void CriarNovaConta(Conta conta);
    void AtualizarDadosConta(Conta conta);
    void ApagarConta(int numero);

    // Métodos financeiros
    void Sacar(int numero, decimal valor);
    void Depositar(int numero, decimal valor);
    void Transferir(int numeroOrigem, int numeroDestino, decimal valor);

}
