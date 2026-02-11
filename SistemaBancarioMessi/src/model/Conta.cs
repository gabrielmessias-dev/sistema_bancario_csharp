using SistemaBancarioMessi.src.controller;

namespace SistemaBancarioMessi.src.model;

internal class Conta : ContaController
{
    public Conta(int numero, string titular, decimal saldo)
    {
        Numero = numero;
        Titular = titular;
        Saldo = saldo;
    }

    public int Numero { get; set; }
    public string Titular { get; set; }
    public decimal Saldo { get; set; }
}
