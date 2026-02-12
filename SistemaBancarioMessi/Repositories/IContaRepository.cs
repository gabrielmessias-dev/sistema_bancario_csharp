using SistemaBancarioMessi.Models;

namespace SistemaBancarioMessi.Repositories;

public interface IContaRepository
{
    // CRUD Conta
    void CriarConta(Conta conta);

    // ? diz que pode retornar null, a conta pode não existir
    Conta? ProcurarPorNumero(int numero);

    List<Conta> ListarTodas();

    void AtualizarConta(Conta conta);

    void Deletar(int numero);

}
