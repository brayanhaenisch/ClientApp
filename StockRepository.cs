using ProdReg;
using ProdRep;

namespace StockReg;

public class StockRepository
{
    public List<Stock> stock = new List<Stock>();


    public void DataSave()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(stock);

        File.WriteAllText("Stock.txt", json);
    }

    public void GetData()
    {
        if (File.Exists("Stock.txt"))
        {
            var dados = File.ReadAllText("Stock.txt");

            var arquive = System.Text.Json.JsonSerializer.Deserialize<List<Stock>>(dados);
            stock.AddRange(arquive);
        }
    }
    
    public void StockPrint(Stock stock)
    {
        Console.WriteLine("ID.............   " + stock.Id);
        Console.WriteLine("Nome...........   " + stock.Name);
        Console.WriteLine("Quantidade.....   " + stock.Quantidade);
        Console.Write(Environment.NewLine);
    }
    public void GetStock()
    {
        Console.Clear();
        Console.WriteLine("Estoque Produtos: ");
        Console.Write(Environment.NewLine);
        stock?.ForEach(p => StockPrint(p));
        Console.WriteLine("Menu [Enter]");
    }
    public void StockAdd()
    {
        Console.Clear();
        Console.Write("Digite a loja: ");
        var store = Console.ReadLine();
        Console.Write("Digite o ID do produto: ");
        var id = Console.ReadLine();
        Console.Write("Digite a quantidade a ser adicionda: ");
        var quantidade = Console.ReadLine();
        var product = new ProductRepository();

        product.GetData();

        var prod = product.products.FirstOrDefault(y => y.Id == int.Parse(id));


        if (prod == null)
        {
            Console.WriteLine("Produto não encontrado! [Enter]");
            return;
        }

        var prodstock = new Stock();
        prodstock.Id = prod.Id;
        prodstock.Name = prod.Name;
        prodstock.Quantidade = int.Parse(quantidade);
        prodstock.Store = int.Parse(store);
        stock.Add(prodstock);
        Console.WriteLine("Estoque adicionado! [Enter]");
    }

    public void StockEdit()
    {
        Console.Clear();
        Console.Write("Digite a loja: ");
        var store = Console.ReadLine();
        Console.Write(Environment.NewLine);
        Console.Write("Digite o ID do produto: ");
        var id = Console.ReadLine();
        Console.Write(Environment.NewLine);
        Console.Write("Digite a quantidade a ser adicionda: ");
        var quantidade = Console.ReadLine();

        var resultado = stock.FirstOrDefault(y => y.Id == int.Parse(id) && y.Store == int.Parse(store));
        if (id == null)
        {
            Console.WriteLine("Produto não encontrado! [Enter]");
            return;
        }

        resultado.Quantidade += int.Parse(quantidade);

        Console.Clear();
        Console.WriteLine($"Estoque do ID {id} alterado!");
        Console.Write(Environment.NewLine);
        StockPrint(resultado);
    } 
}