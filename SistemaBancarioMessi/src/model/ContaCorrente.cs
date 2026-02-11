namespace SistemaBancarioMessi.src.model;

internal class ContaCorrente
{
    // Tem que ter uma taxa a cada saque.
    public decimal TaxaSaque { get; set; } = 5.00m;
    public decimal Saldo { get; set; }
    public void Sacar(decimal valor)
    {
        Saldo -= (valor + TaxaSaque);
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
