namespace CalculoComissao;

public class Vendas
{
    public Vendas(string vendedor, double valor)
    {
        this.vendedor = vendedor;
        this.valor = valor;
    }

    public String vendedor { get; set; }
    public double valor { get; set; }
}