namespace SistemaBancarioMessi.Models;

public class ContaEmpresarial : Conta
{
    public decimal LimiteEmprestimo { get; set; }

    public ContaEmpresarial(int numero, string titular, decimal saldo, decimal limite) 
        : base(numero, titular, saldo) // Chama o construtor da classe pai
    {
        LimiteEmprestimo = limite;
    }

    // Utilização do override para alterar o comportamento do método Sacar da classe Conta
    // Conta empresarial pode sacar até o limite de empréstimo, podendo ficar com saldo negativo até o valor do limite.
    public override void Sacar(decimal valor)
    {
        // A soma do Saldo atual + Limite é o quanto o cara pode gastar
        decimal valorDisponivel = Saldo + LimiteEmprestimo;

        if (valor > valorDisponivel)
        {
            throw new Exception("Saldo e Limite insuficientes!");
        }
        Saldo -= valor;
    }

    // Método Exclusivo
    public void PedirEmprestimo(decimal valor)
    {
        if (valor > LimiteEmprestimo)
        {
            throw new Exception("Valor excede o limite de empréstimo disponível.");
        } else
        {
            Saldo += valor;
            LimiteEmprestimo -= valor;
            // O limite diminui conforme usa
        }

    }

}
