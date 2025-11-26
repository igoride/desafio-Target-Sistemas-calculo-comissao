using System.Text.Json;

namespace CalculoComissao
{
    class Program
    {
        static void Main()
        {
            
            string json;
            
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, @"Assets", "ComissoesJson.txt");
                Console.WriteLine(path);
                json = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                throw;
            }
            
            var dados = JsonSerializer.Deserialize<VendasJson>(json);
            
            var comissoes = new Dictionary<string, double>();

            foreach (var dado in dados!.vendas)
            {
                double comissao = CalcularComissao(dado.valor);

                if (!comissoes.ContainsKey(dado.vendedor))
                {
                    comissoes[dado.vendedor] = 0;
                }
                
                comissoes[dado.vendedor] += comissao;
            }
            
            Console.WriteLine("Comissões por Vendedores:\n");
            foreach (var item in comissoes)
            {
                Console.WriteLine($"{item.Key}: R$ {item.Value:F2}");
            }
        }

        static double CalcularComissao(double valor)
        {
            if (valor < 100) return 0;
            if (valor < 500) return valor * 0.01;
            return valor * 0.05;
        }
    }
}
