namespace SistemaBancarioMessi.Models;

public class ContaPoupanca : Conta
{
    // construtor simples, só chama o construtor da classe pai (Conta) com os dados necessários
    // ContaPoupanca não tem regras especiais, então não precisa de override no método Sacar.

    public ContaPoupanca(int numero, string titular, decimal saldo)
        : base(numero, titular, saldo) { }

    // Método Exclusivo
    public void AtualizarSaldo(decimal taxaRendimento)
    {
        Saldo += Saldo * taxaRendimento;
    }

}
