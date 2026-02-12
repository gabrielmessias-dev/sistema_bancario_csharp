namespace SistemaBancarioMessi.Models;

internal class ContaCorrente : Conta
{
    // Tem que ter uma taxa a cada saque.
    public decimal TaxaSaque { get; set; } = 5.00m;
    public decimal Saldo { get; set; }
    public ContaCorrente(int numero, string titular, decimal saldo)
        : base(numero, titular, saldo)
    {
    }
    public override void Sacar(decimal valor)
    {
        decimal valorTotal = valor + TaxaSaque;

        // Validação se não tiver dinheiro da erro
        if (valorTotal > Saldo)
        {

            throw new Exception("Saldo insuficiente.");
        }
        Saldo -= valorTotal;
    }

    public void Depositar(decimal valor)
    {
        Saldo += valor;
    }
    public void Transferir(ContaCorrente contaDestino, decimal valor)
    {
        Sacar(valor);
        contaDestino.Depositar(valor);
    }

}
