namespace SistemaBancarioMessi.Models;

// abstract - para não instanciar diretamente uma Conta , mas sim suas subclasses (ContaCorrente, ContaPoupanca, etc.)
public abstract class Conta
{
    // construtor - obriga quem herdar passar esses dados para criar uma conta
    public Conta(int numero, string titular, decimal saldoInicial = 0)
    {
        Numero = numero;
        Titular = titular;
        Saldo = saldoInicial;
    }

    public int Numero { get; set; }
    public string Titular { get; set; }
    // protected set - apenas as classes filhas podem alterar o saldo diretamente
    public decimal Saldo { get; protected set; }

    // virtual - permite que as subclasses alterem o comportamento do metodo sacar com override
    public virtual void Sacar(decimal valor)
    {
        if (valor > Saldo)
        {
            throw new Exception("Saldo insuficiente!");
        } else
        {
            Saldo -= valor;
        }
    }

    public void Depositar(decimal valor)
    {
        if (valor < 0) 
        {
            throw new Exception("Valor inválido");
        } else
        {
            Saldo += valor;
        }      
    }

    public void Transferir(Conta destino, decimal valor)
    {
        // Tenta tirar da conta atual (se for Corrente, já cobra taxa aqui!)
        this.Sacar(valor);

        // 2. Se não deu erro no saque, deposita na outra
        destino.Depositar(valor);
    }

}
